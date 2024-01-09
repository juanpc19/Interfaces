using CapaEntidades;
using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class DeleteDep : ContentPage
{
	public DeleteDep(clsDepartamento departamento)
	{
		InitializeComponent();
		//BindingContext = new DeleteDepVM(departamento);
	}
}