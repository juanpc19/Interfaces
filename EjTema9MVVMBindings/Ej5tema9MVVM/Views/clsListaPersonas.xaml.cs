using BibliotecaDeClases;
using Ej5tema9MVVM.Views.ViewModel;

namespace Ej5tema9MVVM.Views;

public partial class clsListaPersonas : ContentPage
{
	public clsListaPersonas()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    //evento navegacion en click en lista personas
    private async void DetallesPersona(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is clsPersona selectedPersona)
        {
            
            await Navigation.PushAsync(new clsPersonaSeleccionada());
        }
    }
}