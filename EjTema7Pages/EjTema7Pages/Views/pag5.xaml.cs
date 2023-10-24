using BibliotecaDeClases;

namespace EjTema7Pages.Views;

public partial class pag5 : ContentPage
{
    /// <summary>
    /// constructor sin parametros que crea pag5
    /// precondiciones: ninguna
    /// postcondiciones: ninguna
    /// </summary>
    public pag5()
    {
    }

    /// <summary>
    /// constructor con parametros de entrada 
    /// precondiciones: necesita que se le pase un objeto tipo persona como param entrada
    /// postcondiciones: ninguna
    /// </summary>
    /// <param name="persona">objeto tipo persona usado en creacion de pagina contendra nombre y apellidos</param>
    public pag5(clsPersona persona)
	{
		InitializeComponent();
		
	}
 
}