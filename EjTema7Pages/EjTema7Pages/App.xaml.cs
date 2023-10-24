using EjTema7Pages.Views;

namespace EjTema7Pages
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //estaba asi cambiar a lo siguiente para hacer de la MainPage una NavigationPage que sea la raiz de la pila

            MainPage = new NavigationPage(new MainPage());
        }
    }
}