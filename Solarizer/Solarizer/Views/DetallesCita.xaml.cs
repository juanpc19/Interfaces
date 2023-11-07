namespace Solarizer.Views;

public partial class DetallesCita : ContentPage
{
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