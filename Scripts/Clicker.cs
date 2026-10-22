using Godot;
using System;

public partial class Clicker : Button
{
	[Export] public float limiteBaseClicksXSegundo = 10f; // Es el limite x defecto
	private int _clicsEnEsteSegundo = 0;
	private float _tiempoAcumulado = 0f;

	public int clicks = 0;
	public int vistas = 0;

	public float probabilidadError = 0f;
	public bool error50_50 = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += Clicks;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
			_tiempoAcumulado += (float)delta;
    	if (_tiempoAcumulado >= 1.0f)
	    {
        	_clicsEnEsteSegundo = 0; // Reiniciamos el contador cada segundo
        	_tiempoAcumulado -= 1.0f;
    	}
	}

	private void Clicks()
	{
	    // Comprueba el limite
	    if (_clicsEnEsteSegundo >= limiteBaseClicksXSegundo)
	    {
			GD.Print ("Demasiados clicks");
    	    return; 
    	}

		// Se suman en caso de no pasarse
   		_clicsEnEsteSegundo++;
    	clicks += 1;
    	vistas += 1;
    	probabilidadError += 10f;

    	GD.Print($"Clicks: {clicks} | Vistas: {vistas} | Prob Error: {probabilidadError}%");

    	if (probabilidadError >= 100f)
    	{
        	probabilidadError = 0f;
        	GD.Print("¡ERROR TRIGGEREADO!"); 
    	}
	}
}
