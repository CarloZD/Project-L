using Godot;

/// <summary>
/// Zona invisible que lleva al jugador a otra escena al pisarla.
/// Se configura desde el Inspector: escena de destino y nombre del punto de llegada.
/// </summary>
public partial class Puerta : Area2D
{
    /// <summary>Escena a la que lleva la puerta.</summary>
    [Export(PropertyHint.File, "*.tscn")] public string EscenaDestino = "";

    /// <summary>Nombre del nodo (por ejemplo, un Marker2D) donde aparece el jugador.</summary>
    [Export] public string PuntoDeLlegada = "";

    public override void _Ready()
    {
        BodyEntered += AlEntrar;
    }

    private void AlEntrar(Node2D cuerpo)
    {
        if (cuerpo is Jugador)
            Transicion.Instancia?.IrA(EscenaDestino, PuntoDeLlegada);
    }
}
