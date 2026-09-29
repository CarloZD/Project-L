using Godot;

/// <summary>
/// Habitante común de Vértice (Forma 1). Pasea cerca de su punto de origen:
/// camina un poco, se detiene, mira alrededor y vuelve a caminar.
/// </summary>
public partial class Civil : Personaje
{
    /// <summary>Hoja de sprites de este civil. Si está vacía, usa la de la escena.</summary>
    [Export] public Texture2D Apariencia;

    /// <summary>Velocidad al pasear, en píxeles por segundo.</summary>
    [Export] public float Velocidad = 35f;

    /// <summary>Distancia máxima a la que se aleja de su punto de origen.</summary>
    [Export] public float RadioPaseo = 48f;

    private static readonly Vector2[] Direcciones = { Vector2.Up, Vector2.Down, Vector2.Left, Vector2.Right };

    private readonly RandomNumberGenerator _azar = new();
    private Vector2 _origen;
    private Vector2 _direccion;
    private float _temporizador;

    public override void _Ready()
    {
        base._Ready();
        if (Apariencia != null)
            Sprite.Texture = Apariencia;
        _origen = GlobalPosition;
        _azar.Randomize();
        ElegirAccion();
    }

    public override void _PhysicsProcess(double delta)
    {
        float d = (float)delta;
        _temporizador -= d;
        if (_temporizador <= 0)
            ElegirAccion();

        // Si se alejó demasiado, vuelve hacia su punto de origen.
        Vector2 haciaOrigen = _origen - GlobalPosition;
        if (_direccion != Vector2.Zero && haciaOrigen.Length() > RadioPaseo && haciaOrigen.Dot(_direccion) < 0)
            _direccion = haciaOrigen.Normalized();

        Velocity = _direccion * Velocidad;
        MoveAndSlide();

        // Si choca con algo (una pared, Leo u otro civil), se detiene.
        if (GetSlideCollisionCount() > 0)
            _direccion = Vector2.Zero;

        Animar(_direccion, d);
    }

    private void ElegirAccion()
    {
        if (_azar.Randf() < 0.45f)
        {
            _direccion = Vector2.Zero;
            _temporizador = _azar.RandfRange(1.5f, 3.5f);
        }
        else
        {
            _direccion = Direcciones[_azar.RandiRange(0, Direcciones.Length - 1)];
            _temporizador = _azar.RandfRange(0.8f, 2f);
        }
    }
}
