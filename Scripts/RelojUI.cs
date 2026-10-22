using Godot;
using System;

public partial class RelojUI : Node2D
{
    [Export] public Label LabelArriba;
    [Export] public Label LabelAbajo;
	[Export] public float animacionRelojSpeed = 0.5f;
    private float relojSpeed = 1.0f;
	[Export] public GameManager _gameManager; 
	

    private float _tiempo = 0f;        // Tiempo "de reloj" acumulado (ya escalado por relojSpeed)
    private int _minutoActual = -1;    // Se muestra en pantalla cada 60 segundos reales
    private bool _animando = false;

    public override void _Process(double delta)
    {
		if (_gameManager != null)
        {
            // Leemos la velocidad del GameManager
            relojSpeed = _gameManager.relojSpeed;
        }
		else GD.Print("Error no GameManager");

        // relojSpeed = 1 -> tiempo normal
        // relojSpeed = 60 -> un "minuto" cada segundo real
        // relojSpeed = 0.5 -> un "minuto" cada 120 segundos reales
        _tiempo += (float)delta * relojSpeed;
		//GD.Print("Segundos internos: " + _tiempo.ToString("F2"));

        int minutoEntero = Mathf.FloorToInt(_tiempo / 60f); // Cada hora durara "60 ticks" ya que no seran segundos reales, si no que dependeran de relojSpeed

        if (minutoEntero != _minutoActual)
        {
            _minutoActual = minutoEntero;
            IniciarAnimacion(minutoEntero);
        }
    }

    private async void IniciarAnimacion(int nuevoMinuto)
    {
        string textoNuevo = $"{nuevoMinuto:D2}:00";
        string textoViejo = $"{Mathf.Max(0, nuevoMinuto - 1):D2}:00";

        // Funcion para evitar solapar animaciones: si ya hay una en curso, la saltamos.
        if (_animando)
        {
            LabelAbajo.Text = textoNuevo;
            LabelArriba.Text = textoViejo;
            return;
        }

        _animando = true;

        // Asignamos el texto formateado
        LabelAbajo.Text = textoNuevo;
        LabelArriba.Text = textoViejo;

        // Posiciones iniciales
        LabelAbajo.Position = new Vector2(0, 50);
        LabelArriba.Position = new Vector2(0, 0);

        // Animación con Tween
        Tween tween = CreateTween();
        tween.TweenProperty(LabelAbajo, "position:y", 0.0f, animacionRelojSpeed);          // El de abajo sube al centro
        tween.Parallel().TweenProperty(LabelArriba, "position:y", -50.0f, animacionRelojSpeed); // El de arriba sube y desaparece
        await ToSignal(tween, Tween.SignalName.Finished);

        _animando = false;
    }
}