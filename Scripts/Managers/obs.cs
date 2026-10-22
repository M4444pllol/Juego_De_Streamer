using Godot;

// Al poner : Button, el script sabe que es un botón
public partial class obs : Button 
{
    [Export] public Control _menuOBS;

    [Export] public Button BtnCamara;
    [Export] public Button BtnRendimiento;
    [Export] public Button BtnEscenas;
    [Export] public Button BtnEntrada;
    [Export] public Button BtnAudio;

    public override void _Ready()
    {
        //if (_menuOBS != null) _menuOBS.Visible = false;
        this.Pressed += MostrarMenu; //This = referirme al propio objeto del codigo

        if (BtnCamara != null) BtnCamara.Pressed += () => SeleccionarOpcion("Cámara");
        if (BtnRendimiento != null) BtnRendimiento.Pressed += () => SeleccionarOpcion("Rendimiento");
        if (BtnEscenas != null) BtnEscenas.Pressed += () => SeleccionarOpcion("Escenas");
        if (BtnEntrada != null) BtnEntrada.Pressed += () => SeleccionarOpcion("Entrada");
        if (BtnAudio != null) BtnAudio.Pressed += () => SeleccionarOpcion("Audio");

    }

    private void MostrarMenu()
    {
        if (_menuOBS != null) _menuOBS.Visible = true; 
        this.Visible = false; 
    }

    private void SeleccionarOpcion(string nombreOpcion)
    {
        GD.Print("Has seleccionado: " + nombreOpcion);
        
        if (_menuOBS != null) _menuOBS.Visible = false; 
        this.Visible = true; 
    }
}