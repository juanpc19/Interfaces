using BibliotecaDeClases;
using System.Diagnostics;

namespace Ejercicio2Tema5PrimerMaui
{
    public partial class MainPage : ContentPage
    {
        private object persona;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            //codigo para usar MainPage.xaml y MauiProgram.cs
            // string apellidos = await metodoPrompt();
            // helloWorld.Text = $"Hola, {entryNombre.Text} {apellidos}";

            //codigo usando clase persona
            string nombre = entryNombre.Text;
            string apellidos = await metodoPrompt();
            
            clsPersona persona = new (nombre, apellidos);
            string tal = persona.NombreCompleto ;
            
            helloWorld.Text = $"Hola {tal}";

        }

        private async Task<string> metodoPrompt()
        {
            return await DisplayPromptAsync("Apellidos", "Introduce tus apellidos:");
        }

    }
}