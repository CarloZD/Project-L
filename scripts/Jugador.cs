using Godot;

/// <summary>
/// Leo en el mundo: se mueve con WASD o flechas, choca con las paredes,
/// anima su sprite según la dirección y lleva una cámara que lo sigue.
/// </summary>
public partial class Jugador : CharacterBody2D
{
	/// <summary>Velocidad en píxeles por segundo. Editable desde el Inspector.</summary>
	[Export] public float Velocidad = 120f;

	/// <summary>Cuadros de animación por segundo al caminar.</summary>
	[Export] public float VelocidadAnimacion = 8f;

	// Filas de la hoja de sprites (3 columnas: quieto, paso A, paso B).
	private const int FilaAbajo = 0;
	private const int FilaIzquierda = 1;
	private const int FilaDerecha = 2;
	private const int FilaArriba = 3;
	private const int Columnas = 3;

	// Ciclo de caminata: paso A, quieto, paso B, quieto.
	private static readonly int[] CicloCaminar = { 1, 0, 2, 0 };

	private Camera2D _camara;
	private Sprite2D _sprite;
	private int _fila = FilaAbajo;
	private float _tiempoAnimacion;

	public override void _Ready()
	{
		_camara = GetNode<Camera2D>("Camara");
		_sprite = GetNode<Sprite2D>("Sprite");
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

	private void Animar(Vector2 direccion, float delta)
	{
		if (direccion == Vector2.Zero)
		{
			_tiempoAnimacion = 0;
			_sprite.Frame = _fila * Columnas;   // quieto, mirando a la última dirección
			return;
		}

		// La dirección dominante decide hacia dónde mira.
		if (Mathf.Abs(direccion.X) > Mathf.Abs(direccion.Y))
			_fila = direccion.X > 0 ? FilaDerecha : FilaIzquierda;
		else
			_fila = direccion.Y > 0 ? FilaAbajo : FilaArriba;

		_tiempoAnimacion += delta * VelocidadAnimacion;
		int paso = CicloCaminar[(int)_tiempoAnimacion % CicloCaminar.Length];
		_sprite.Frame = _fila * Columnas + paso;
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
