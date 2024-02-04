using CapaEntidades;
using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class EditPersona : ContentPage
{
	public EditPersona(clsPersona persona, clsDepartamento departamento)
	{
		InitializeComponent();
		BindingContext = new EditPersonaVM(persona, departamento);
	}
}