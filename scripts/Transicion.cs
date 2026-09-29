using Godot;

/// <summary>
/// Sistema global de transiciones (autoload): funde a negro, cambia de escena
/// y coloca al jugador en el punto de llegada indicado.
/// </summary>
public partial class Transicion : CanvasLayer
{
    /// <summary>Acceso directo desde cualquier script.</summary>
    public static Transicion Instancia { get; private set; }

    /// <summary>Duración de cada fundido, en segundos.</summary>
    [Export] public float DuracionFundido = 0.25f;

    private ColorRect _velo;
    private bool _enCurso;

    public override void _Ready()
    {
        Instancia = this;
        _velo = GetNode<ColorRect>("Velo");
        _velo.Color = new Color(0, 0, 0, 0);
    }

    /// <summary>
    /// Cambia a otra escena y pone al jugador sobre el nodo llamado <paramref name="puntoDeLlegada"/>.
    /// </summary>
    public async void IrA(string escena, string puntoDeLlegada)
    {
        if (_enCurso || string.IsNullOrEmpty(escena))
            return;
        _enCurso = true;

        // Congela el juego mientras dura la transición (este nodo sigue funcionando).
        GetTree().Paused = true;
        await Fundir(1f);

        GetTree().ChangeSceneToFile(escena);
        // El cambio de escena se aplica en el siguiente cuadro.
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

        Node actual = GetTree().CurrentScene;
        var jugador = actual?.GetNodeOrNull<Jugador>("Jugador");
        var marca = actual?.FindChild(puntoDeLlegada, true, false) as Node2D;
        if (jugador != null && marca != null)
            jugador.Llegar(marca.GlobalPosition);
        else
            GD.PushWarning($"Transición: no se encontró el punto de llegada '{puntoDeLlegada}' en {escena}.");

        GetTree().Paused = false;
        await Fundir(0f);
        _enCurso = false;
    }

    private SignalAwaiter Fundir(float alfaFinal)
    {
        Tween tween = CreateTween();
        tween.TweenProperty(_velo, "color:a", alfaFinal, DuracionFundido);
        return ToSignal(tween, Tween.SignalName.Finished);
    }
}
