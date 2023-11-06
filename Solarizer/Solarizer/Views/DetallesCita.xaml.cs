namespace Solarizer.Views;

public partial class DetallesCita : ContentPage
{
	public DetallesCita()
	{
		InitializeComponent();
	}

    
        public void VolverListadoCitas(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}