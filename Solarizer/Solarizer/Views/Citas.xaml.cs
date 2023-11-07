using Solarizer.Models;
using System.Collections.ObjectModel;
namespace Solarizer.Views;


public partial class Citas : ContentPage
{
    //creo lista observable de objetos Cita de nombre listadoPersonas
    //y le doy valor igual a lista observable devuelta por getListadoCitas de la clase estatica ListadoCitas 
    ObservableCollection<Cita> listadoPersonas = ListadoCitas.getListadoCitas();

    /// <summary>
    /// inicializa pagina Citas 
    /// </summary>
    public Citas()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        //doy a list view de nombre ListadoDeCitas una fuente de items con listadoPersonas
        ListadoDeCitas.ItemsSource = listadoPersonas;
    }

    /// <summary>
    /// metodo que devolvera a pagina Login
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void VolverLogin(object sender, EventArgs e)
    {
        //Hago push porque no es necesario preservar datos del login
        Navigation.PushAsync(new Login());
    }

    public void Detalles(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DetallesCita());
    }
}