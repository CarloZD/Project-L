using Godot;

/// <summary>
/// Base para todo personaje que camina por el mundo con una hoja de sprites
/// de 3 columnas (quieto, paso A, paso B) y 4 filas (abajo, izquierda, derecha, arriba).
/// </summary>
public partial class Personaje : CharacterBody2D
{
    /// <summary>Cuadros de animación por segundo al caminar.</summary>
    [Export] public float VelocidadAnimacion = 8f;

    protected const int FilaAbajo = 0;
    protected const int FilaIzquierda = 1;
    protected const int FilaDerecha = 2;
    protected const int FilaArriba = 3;
    protected const int Columnas = 3;

    // Ciclo de caminata: paso A, quieto, paso B, quieto.
    private static readonly int[] CicloCaminar = { 1, 0, 2, 0 };

    protected Sprite2D Sprite;
    private int _fila = FilaAbajo;
    private float _tiempoAnimacion;

    public override void _Ready()
    {
        Sprite = GetNode<Sprite2D>("Sprite");
    }

    /// <summary>Elige el cuadro según la dirección de movimiento.</summary>
    protected void Animar(Vector2 direccion, float delta)
    {
        if (direccion == Vector2.Zero)
        {
            _tiempoAnimacion = 0;
            Sprite.Frame = _fila * Columnas;   // quieto, mirando a la última dirección
            return;
        }

        // La dirección dominante decide hacia dónde mira.
        if (Mathf.Abs(direccion.X) > Mathf.Abs(direccion.Y))
            _fila = direccion.X > 0 ? FilaDerecha : FilaIzquierda;
        else
            _fila = direccion.Y > 0 ? FilaAbajo : FilaArriba;

        _tiempoAnimacion += delta * VelocidadAnimacion;
        int paso = CicloCaminar[(int)_tiempoAnimacion % CicloCaminar.Length];
        Sprite.Frame = _fila * Columnas + paso;
    }
}
