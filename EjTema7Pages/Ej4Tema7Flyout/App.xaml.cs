namespace Ej4Tema7Flyout
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlyoutPageNavigation();
        }
    }
}