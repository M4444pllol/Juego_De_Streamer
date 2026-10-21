using Godot;
using System;

public partial class GameManager : Node2D
{
	double Contador_Vistas = 0;
	double Contador_Dineros = 0;
	double Contador_Subs = 0;
	int tiempo = 0;
	public float reloj = 0.0f;
	[Export] public float relojSpeed = 1.0f;
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
            GD.Print("Segundos jugados: " + Mathf.FloorToInt(reloj));
        }

	}
}