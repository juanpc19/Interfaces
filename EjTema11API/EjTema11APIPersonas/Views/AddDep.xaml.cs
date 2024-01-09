using EjTema11APIPersonas.ViewModels;

namespace EjTema11APIPersonas.Views;

public partial class AddDep : ContentPage
{
	public AddDep()
	{
		InitializeComponent();
		BindingContext = new AddDepVM();
	}
}