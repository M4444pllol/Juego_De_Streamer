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
    [Export] public float _velocidadFondo = 222.0f;
    [Export] public float _velocidadExtra =2.5f;
    [Export] public float _limiteCamara =720.0f;

    public override void _Ready()
    {
        FondoDia.xFont = 0;
        Position = Vector2.Zero;
            // Referencias a las areas con Hover para controlar "la camara"
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

    float ratonSegundo, ratonPrimero, posicionCam = 0.0f;
    public override void _Process(double delta)
    {
		//Movimiento en deltaTime del fondo
        if (_ratonEnL && FondoDia.xFont < _limiteCamara)
        {
            FondoDia.xFont += _velocidadFondo * (float)delta;
            ratonPrimero += 0.1f;
                // ratonPrimero/ratonSegundo son contadores independientes que al llegar a 3 cambian la velocidad, mientras que FondoDia.xFont es simplemente la variable x de FondoDia
            if (_ratonEnL && ratonPrimero>=3f)
		    {
                // Se le suma la velocidad extra cuando lleba 3 segundos
                FondoDia.xFont += _velocidadFondo * (float)delta + _velocidadExtra;
		    }
        }
		else
		{
			ratonPrimero = 0f;
		}
            // Lo mismo que el de arriba
		if (_ratonEnR && FondoDia.xFont > -_limiteCamara)
        {
            FondoDia.xFont -= _velocidadFondo * (float)delta;
            ratonSegundo += 0.1f;

            if (_ratonEnR && ratonSegundo>=3f)
		    {
                FondoDia.xFont -= _velocidadFondo * (float)delta + _velocidadExtra;
		    }
        }
		else
		{
			ratonSegundo = 0f;
		}
    }
}
