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
    private void NavToTabbedPage(object sender, EventArgs e)
	{
		Navigation.PushAsync(new PaginaTabbed());
	}

    //por hacer
    private void NavToPage4(object sender, EventArgs e)
    {
        

        string nombres = entryNombres.Text;

        string apellidos = entryApellidos.Text;

        clsPersona persona = new(nombres, apellidos);

        Navigation.PushAsync(new pag4());
    }

    //por hacer
    private void NavToPage5(object sender, EventArgs e)
    {

        string nombres = entryNombres.Text;
        string apellidos = entryApellidos.Text;

        clsPersona persona = new(nombres, apellidos);

        pag5 pag5 = new pag5();

        pag5.BindingContext = persona;

        Navigation.PushAsync(pag5);
         
    }

}