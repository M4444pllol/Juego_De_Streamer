using Godot;
using System;

public partial class Camera2d : Camera2D
{
	private Area2D _cameraL;
    private Area2D _cameraR;
    [Export] public FondoDia FondoDia;

    // Señal de donde esta el raton
    private bool _ratonEnL = false;
    private bool _ratonEnR = false;

    // Velocidad del Fondo
    private float _velocidadFondo = 188.0f;

    public override void _Ready()
    {
        FondoDia.xFont = 0;
        Position = Vector2.Zero;

        _cameraL = GetNode<Area2D>("Camera_L"); 
        _cameraR = GetNode<Area2D>("Camera_R");

        // Encendiddo y apagado de las señales
        if (_cameraL != null)
        {
            _cameraL.MouseEntered += () => _ratonEnL = true;
            _cameraL.MouseExited += () => _ratonEnL = false;
        }

        if (_cameraR != null)
        {
            _cameraR.MouseEntered += () => _ratonEnR = true;
            _cameraR.MouseExited += () => _ratonEnR = false;
        }
    }

    float ratonSegundo = 0.0f;
    public override void _Process(double delta)
    {

		//Movimiento en deltaTime del fondo
        if (_ratonEnL)
        {
            FondoDia.xFont += _velocidadFondo * (float)delta;
            
        }
        
		if (_ratonEnR)
        {
            FondoDia.xFont -= _velocidadFondo * (float)delta;
            ratonSegundo += 0.01f;
			GD.Print("AAAA:",ratonSegundo);
        }
		else if (_ratonEnR && ratonSegundo>=3f)
		{
			GD.Print("Eeeepa:",ratonSegundo);
			
		}
		else
		{
			ratonSegundo = 0f;
		}
    }
}
