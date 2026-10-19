using Godot;
using System;

public partial class FondoDia : Sprite2D
{

	//Velocidad de movimieto del Fondo
	public float xFont = 0.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Reinicia su posicion X e Y a 0
		Position = Vector2.Zero;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(xFont, Position.Y);
	}
}
