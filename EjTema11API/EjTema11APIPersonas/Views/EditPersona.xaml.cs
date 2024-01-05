using CapaEntidades;
using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class EditPersona : ContentPage
{
	public EditPersona(clsPersona persona)
	{
		InitializeComponent();
		BindingContext = new EditPersonaVM(persona);
	}
}