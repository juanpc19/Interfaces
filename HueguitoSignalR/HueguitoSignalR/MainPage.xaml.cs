using HueguitoSignalR.ViewModels;

namespace HueguitoSignalR
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string nombreJugador)
        {
            InitializeComponent();
            BindingContext= new JuegoVM(nombreJugador);
        }
    }
}