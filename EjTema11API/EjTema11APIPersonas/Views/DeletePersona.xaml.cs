using CapaEntidades;
using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class DeletePersona : ContentPage
{
	public DeletePersona(clsPersona persona)
	{
		InitializeComponent();
		BindingContext = new DeletePersonaVM(persona);
	}
}