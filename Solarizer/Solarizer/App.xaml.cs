using Solarizer.Views;
namespace Solarizer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //modifico esto a siguiente linea para hacer de main page la primera pagina de navegacion en mi pila de paginas
            MainPage = new NavigationPage(new Citas());
        }
    }
}