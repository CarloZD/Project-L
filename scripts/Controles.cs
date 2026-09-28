using Godot;

/// <summary>
/// Registra las acciones de control del juego (WASD y flechas).
/// Se definen en código para tenerlas versionadas y en un solo lugar.
/// </summary>
public static class Controles
{
    public const string Izquierda = "mover_izquierda";
    public const string Derecha = "mover_derecha";
    public const string Arriba = "mover_arriba";
    public const string Abajo = "mover_abajo";

    public static void Registrar()
    {
        Agregar(Izquierda, Key.A, Key.Left);
        Agregar(Derecha, Key.D, Key.Right);
        Agregar(Arriba, Key.W, Key.Up);
        Agregar(Abajo, Key.S, Key.Down);
    }

    private static void Agregar(string accion, params Key[] teclas)
    {
        if (InputMap.HasAction(accion))
            return;

        InputMap.AddAction(accion);
        foreach (Key tecla in teclas)
        {
            // PhysicalKeycode usa la posición de la tecla, así WASD funciona
            // igual en teclados en español, inglés u otros.
            InputMap.ActionAddEvent(accion, new InputEventKey { PhysicalKeycode = tecla });
        }
    }
}
