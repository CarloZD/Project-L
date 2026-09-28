using Godot;

/// <summary>
/// Escena principal: prepara los controles, conecta el mapa con la cámara,
/// muestra los FPS y permite salir con Esc.
/// </summary>
public partial class Juego : Node2D
{
    private const string Titulo = "Project Hero \"L\"";

    /// <summary>Muestra los FPS en la barra de título (depuración).</summary>
    [Export] public bool MostrarFps = true;

    public override void _EnterTree()
    {
        // Se ejecuta antes que el _Ready de los hijos, así los controles
        // existen antes de que el jugador los lea.
        Controles.Registrar();
    }

    public override void _Ready()
    {
        var mapa = GetNode<TileMapLayer>("Mapa");
        var jugador = GetNode<Jugador>("Jugador");

        if (mapa.TileSet == null)
        {
            GD.PushError("El TileSet del mapa no se pudo cargar. Abre el proyecto una vez " +
                         "en el editor de Godot para que importe las imágenes nuevas.");
            return;
        }

        jugador.LimitarCamara(CalcularLimites(mapa));
    }

    public override void _Process(double delta)
    {
        if (MostrarFps)
            GetWindow().Title = $"{Titulo}  |  {Engine.GetFramesPerSecond()} FPS";
    }

    public override void _UnhandledInput(InputEvent evento)
    {
        // ui_cancel viene incluida en Godot y usa la tecla Esc.
        if (evento.IsActionPressed("ui_cancel"))
            GetTree().Quit();
    }

    /// <summary>Rectángulo en píxeles que ocupan los tiles pintados del mapa.</summary>
    private static Rect2 CalcularLimites(TileMapLayer mapa)
    {
        Rect2I celdas = mapa.GetUsedRect();
        Vector2 tamanoTile = mapa.TileSet.TileSize;
        Vector2 inicio = mapa.ToGlobal((Vector2)celdas.Position * tamanoTile);
        Vector2 fin = mapa.ToGlobal((Vector2)celdas.End * tamanoTile);
        return new Rect2(inicio, fin - inicio);
    }
}
