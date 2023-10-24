using BibliotecaDeClases;

namespace EjTema7Pages.Views;

public partial class pag4 : ContentPage
{
	 
    //constructor sin parametros
	public pag4()
	{
		InitializeComponent();
	}
    //constructor con parametros
    public pag4(clsPersona persona)
    {
        InitializeComponent();
        labNombres.Text = persona.Nombre;
        labApellidos.Text = persona.apellido;
    }

    //POR HACER
    public void MostrarPersonaParametros(object sender, EventArgs e)
    {

	}
}