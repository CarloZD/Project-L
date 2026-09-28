using Godot;

/// <summary>
/// Escena principal: prepara los controles, muestra los FPS y permite salir con Esc.
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
}
