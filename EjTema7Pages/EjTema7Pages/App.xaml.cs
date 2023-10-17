using EjTema7Pages.Views;

namespace EjTema7Pages
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaTabbed();
        }
    }
}