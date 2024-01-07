using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class AddPersona : ContentPage
{
	public AddPersona()
	{
		InitializeComponent();
		BindingContext = new AddPersonaVM();
	}
}