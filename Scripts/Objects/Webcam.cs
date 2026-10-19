using Godot;

public partial class Webcam : Sprite2D
{
    [Export] public Texture2D TexturaA;
    [Export] public Texture2D TexturaB;

    // Tirmpo de intercambio
    [Export] public float Intervalo = 1.5f;

    private bool _mostrandoA = true;
    private Timer _timer;

    public override void _Ready()
    {
        // 1. Nos aseguramos de empezar con la textura A
        if (TexturaA != null) Texture = TexturaA;

        // 2. Creamos el temporizador por código
        _timer = new Timer();
        _timer.WaitTime = Intervalo; // Le pasamos tu variable
        _timer.OneShot = false;      // Que se repita infinitamente
        _timer.Autostart = true;     // Que empiece solo al cargar la escena
        
        // 3. Conectamos el temporizador a una función
        _timer.Timeout += CambiarTextura;
        
        // 4. Lo añadimos al nodo
        AddChild(_timer);
    }

    private void CambiarTextura()
    {
        // Invertimos el estado
        _mostrandoA = !_mostrandoA;

        if (_mostrandoA)
        {
            Texture = TexturaA;
        }
        else
        {
            Texture = TexturaB;
        }
    }
}