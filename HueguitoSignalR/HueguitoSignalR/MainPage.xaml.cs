using HueguitoSignalR.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace HueguitoSignalR
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string nombreJugador, HubConnection conexion)
        {
            InitializeComponent();
            BindingContext= new JuegoVM(nombreJugador, conexion);
        }
    }
}