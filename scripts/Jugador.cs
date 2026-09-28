using Godot;

/// <summary>
/// Jugador provisional: un cuadrado verde controlado con WASD o flechas.
/// Es un CharacterBody2D para que en la Fase 2 choque con paredes sin cambiar nada.
/// </summary>
public partial class Jugador : CharacterBody2D
{
    /// <summary>Velocidad en píxeles por segundo. Editable desde el Inspector.</summary>
    [Export] public float Velocidad = 300f;

    /// <summary>Tamaño del cuadrado, usado para no salir de la pantalla.</summary>
    [Export] public Vector2 Tamano = new Vector2(40, 40);

    public override void _PhysicsProcess(double delta)
    {
        // GetVector ya normaliza la diagonal: en diagonal no va más rápido.
        Vector2 direccion = Input.GetVector(
            Controles.Izquierda, Controles.Derecha,
            Controles.Arriba, Controles.Abajo);

        // Velocity está en píxeles por segundo; MoveAndSlide aplica el delta.
        Velocity = direccion * Velocidad;
        MoveAndSlide();

        LimitarAPantalla();
    }

    /// <summary>Mantiene al jugador dentro de la ventana.</summary>
    private void LimitarAPantalla()
    {
        Rect2 area = GetViewportRect();
        Vector2 mitad = Tamano / 2;
        GlobalPosition = GlobalPosition.Clamp(area.Position + mitad, area.End - mitad);
    }
}
