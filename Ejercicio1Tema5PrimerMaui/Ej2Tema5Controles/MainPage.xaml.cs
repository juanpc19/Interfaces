namespace Ej2Tema5Controles
{
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
       
        private void OnClick(object sender, EventArgs e)
        {
            // MainPage mainPage = new MainPage();
            // await Navigation.PushAsync(mainPage);
             Navigation.PushAsync(new MainPageOtra());
        }
    }
}