using Godot;

/// <summary>
/// Leo en el mundo: se mueve con WASD o flechas, choca con las paredes,
/// anima su sprite según la dirección y lleva una cámara que lo sigue.
/// </summary>
public partial class Jugador : Personaje
{
    /// <summary>Velocidad en píxeles por segundo. Editable desde el Inspector.</summary>
    [Export] public float Velocidad = 120f;

    private Camera2D _camara;

    public override void _Ready()
    {
        base._Ready();
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

        Animar(direccion, (float)delta);
    }

    /// <summary>
    /// Coloca al jugador en un punto al llegar a una escena (por ejemplo, tras cruzar una puerta).
    /// </summary>
    public void Llegar(Vector2 posicion)
    {
        GlobalPosition = posicion;
        Velocity = Vector2.Zero;
        _camara.ResetSmoothing();   // la cámara salta al punto en vez de desplazarse
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
