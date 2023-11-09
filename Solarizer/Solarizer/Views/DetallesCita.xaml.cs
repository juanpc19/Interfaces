using Solarizer.Models;

namespace Solarizer.Views;

public partial class DetallesCita : ContentPage
{

    //y aqui pasarle la cita en param entrada

    //private clsCita cita;
    //clsCita cita2
    //cita = cita2;
    public DetallesCita()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

    }

    
        public void VolverListadoCitas(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}