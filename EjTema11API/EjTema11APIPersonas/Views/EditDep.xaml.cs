using CapaEntidades;
using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class EditDep : ContentPage
{
	public EditDep(clsDepartamento departamento)
	{
		InitializeComponent();
		//BindingContext = new EditDepVM(departamento);
	}
}