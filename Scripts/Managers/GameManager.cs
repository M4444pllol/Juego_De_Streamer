using Godot;
using System;

// TODAS LAS FUNCIONES IMPORTANTES DEL JUEGO EMPIEZAN POR: Game  como GamePause o GGameReboot
public partial class GameManager : Node2D
{
	[Export] public bool GamePause;
	[Signal] public delegate void JuegoReiniciadoEventHandler();
	/* -------------- */
	[Export] public int vistas = 0;
	[Export] public int seguidores = 0;
	[Export] public int fans = 0;

	/* Variables permanentes de cada guardado */
	[Export] public long dinero = 0; // Money Money Money
	[Export] public float tiempo_reaccion = 1.0f; // Segundos para reaccionar

	/* --------------*/
	double Contador_Vistas = 0;
	double Contador_Dineros = 0;
	double Contador_Subs = 0;
	int tiempo = 0;
	public float reloj = 0.0f;
	[Export] public float relojSpeed = 2.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("¡El GameManager está vivo y funcionando!");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Calculo e impresion de los segundos
		reloj += (float)delta * relojSpeed;
		if (Mathf.FloorToInt(reloj) != Mathf.FloorToInt(reloj - ((float)delta * relojSpeed)))
        {
			//¡ GD.Print("Segundos jugados: " + Mathf.FloorToInt(reloj));
        }

	}
		// Funcion para reiniciar el juego
	public void GameReboot()
    {
        GD.Print("El juego se ha reiniciado.");

        // Emite la señal para reiniciar
        EmitSignal(SignalName.JuegoReiniciado);

        // ¿Obcional? Funcion para recargar la escena actual
        // GetTree().ReloadCurrentScene();
    }
}