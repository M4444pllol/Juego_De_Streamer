using Godot;

public partial class ControladorOBS : Node
{
    private Button _OBS;
    private Control _menuOBS;

    public override void _Ready()
    {
        _OBS = GetNode<Button>("_OBS");
        _menuOBS = GetNode<Control>("_menuOBS");

        _menuOBS.Visible = false; // Ojo que empieza oculto

        _OBS.Pressed += MostrarMenu;

        // Conexion de los botones
        GetNode<Button>("Menu_OBS/ColorRect/Btn_Camara").Pressed += () => SeleccionarOpcion("Cámara");
        GetNode<Button>("Menu_OBS/ColorRect/Btn_Rendimiento").Pressed += () => SeleccionarOpcion("Rendimiento");
        GetNode<Button>("Menu_OBS/ColorRect/Btn_Escenas").Pressed += () => SeleccionarOpcion("Escenas");
        GetNode<Button>("Menu_OBS/ColorRect/Btn_Entrada").Pressed += () => SeleccionarOpcion("Entrada");
        GetNode<Button>("Menu_OBS/ColorRect/Btn_Audio").Pressed += () => SeleccionarOpcion("Audio");
    }

    private void MostrarMenu()
    {
        _menuOBS.Visible = true; 
        _OBS.Visible = false; 
    }

    private void SeleccionarOpcion(string nombreOpcion)
    {
        GD.Print("Has seleccionado: " + nombreOpcion);
        
        _menuOBS.Visible = false; 
        _OBS.Visible = true; 
    }
}