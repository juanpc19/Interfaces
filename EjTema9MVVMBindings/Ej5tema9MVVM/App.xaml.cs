using Ej5tema9MVVM.Views;

namespace Ej5tema9MVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new clsListaPersonas());
        }
    }
}