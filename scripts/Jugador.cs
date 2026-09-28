using Godot;

/// <summary>
/// Jugador provisional: un cuadrado verde controlado con WASD o flechas.
/// Choca con las paredes del mapa y lleva una cámara que lo sigue.
/// </summary>
public partial class Jugador : CharacterBody2D
{
    /// <summary>Velocidad en píxeles por segundo. Editable desde el Inspector.</summary>
    [Export] public float Velocidad = 200f;

    private Camera2D _camara;

    public override void _Ready()
    {
        _camara = GetNode<Camera2D>("Camara");
    }

    public override void _PhysicsProcess(double delta)
    {
        // GetVector ya normaliza la diagonal: en diagonal no va más rápido.
        Vector2 direccion = Input.GetVector(
            Controles.Izquierda, Controles.Derecha,
            Controles.Arriba, Controles.Abajo);

        // MoveAndSlide detiene al jugador en las paredes y lo deja deslizarse
        // a lo largo de ellas en vez de quedarse pegado.
        Velocity = direccion * Velocidad;
        MoveAndSlide();
    }

    /// <summary>
    /// Impide que la cámara muestre lo que hay fuera del mapa.
    /// </summary>
    public void LimitarCamara(Rect2 limites)
    {
        _camara.LimitLeft = (int)limites.Position.X;
        _camara.LimitTop = (int)limites.Position.Y;
        _camara.LimitRight = (int)limites.End.X;
        _camara.LimitBottom = (int)limites.End.Y;
    }
}
