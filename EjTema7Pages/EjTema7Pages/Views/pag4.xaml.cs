using BibliotecaDeClases;

namespace EjTema7Pages.Views;

public partial class pag4 : ContentPage
{

    /// <summary>
    /// constructor sin parametros que crea pag4
    /// precondiciones: ninguna
    /// postcondiciones: ninguna
    /// </summary>
    public pag4()
	{
		InitializeComponent();
	}

    /// <summary>
    /// constructor con parametros de entrada que crea pag4 tomando los valores de los atributos de objeto persona y asignadolos a los text de label
    /// precondiciones: necesita que se le pase un objeto tipo persona como param entrada
    /// postcondiciones: ninguna
    /// </summary>
    /// <param name="persona">objeto tipo persona usado en creacion de pagina contendra nombre y apellidos</param>
    public pag4(clsPersona persona)
    {
        InitializeComponent();
        labNombres.Text = persona.Nombre;
        labApellidos.Text = persona.Apellidos;
    }

}