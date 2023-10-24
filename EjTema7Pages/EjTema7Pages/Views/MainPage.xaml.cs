using BibliotecaDeClases;


namespace EjTema7Pages.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();	 
    }

    //puede ser asi tambien,
    // private async void OnClick(object sender, EventArgs e)
    // await Navigation.PushAsync(new MainPageOtra());

    //el async y el await no son necesarios porque el pushAsync es un metodo sincrono y no devuelve
    //una tarea por la que haya que esperar, si hay que esperar usar lo otro porque es metodo asincrono
    //(en segundo plano) un ejemplo de asincrono seria el prompt que pide nombre del ej anterior:
    //private async Task<string> metodoPrompt()
    //{
    //    return await DisplayPromptAsync("Apellidos", "Introduce tus apellidos:");
    //}

    /// <summary>
    /// funcion que permitira ir a PaginaTabbed al hacer click en su boton correspondiente
    /// precondiciones: hacer click en el boton correspondiente
    /// postcondiciones: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NavToTabbedPage(object sender, EventArgs e)
	{
		Navigation.PushAsync(new PaginaTabbed());
	}

    /// <summary>
    /// funcion que permitira ir a Pagina4 al hacer click en su boton correspondiente
    /// creando a su vez un objeto tipo persona de nombre y apellidos iguales a los proporcionados en el elemento entry
    /// precondiciones: hacer click en el boton correspondiente
    /// postcondiciones: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NavToPage4(object sender, EventArgs e)
    {

        string nombre = entryNombre.Text;
        string apellidos = entryApellidos.Text;

        clsPersona persona = new(nombre, apellidos);

        Navigation.PushAsync(new pag4(persona));
    }

    /// <summary>
    /// funcion que permitira ir a Pagina5 al hacer click en su boton correspondiente
    /// creando a su vez un objeto tipo persona de nombre y apellidos iguales a los proporcionados en el elemento entry
    /// precondiciones: hacer click en el boton correspondiente
    /// postcondiciones: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NavToPage5(object sender, EventArgs e)
    {

        clsPersona persona = new clsPersona();

        persona.Nombre = entryNombre.Text;
        persona.Apellidos = entryApellidos.Text;

         Navigation.PushAsync(new pag5(persona)
        {
            BindingContext = persona
        }
         );
      

    }

}