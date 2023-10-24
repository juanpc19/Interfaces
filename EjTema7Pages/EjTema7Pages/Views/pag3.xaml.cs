namespace EjTema7Pages.Views;

public partial class pag3 : ContentPage
{
	public pag3()
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
    /// funcion que permitira volver a la pagina de navegacion root (Main page) quitando pag de pila (creo que solo funciona con una pagina encima)
    /// precondiciones: hacer click en el boton correspondiente
    /// postcondiciones: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NavToMainPage(object sender, EventArgs e)
	{
        //al volver a main page el texto se borra porque creo una nueva instancia de main page que no tiene datos al ser nueva
        //puedo usar Navigation.PopAsync(); de la siguiente manera para quitar page3 de la pila (estaria arriba del todo)
        //pero al quitarla con un pop no creo una nueva main paga sino que vuelvo a la existente reteniendo la informacion en main page
        Navigation.PopAsync();
        //Navigation.PushAsync(new MainPage());
	}
}