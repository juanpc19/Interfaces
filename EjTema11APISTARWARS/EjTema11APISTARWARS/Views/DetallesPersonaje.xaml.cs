using CapaBL.Listados;
using CapaEntidades;
using EjTema11APISTARWARS.ViewModels;

namespace EjTema11APISTARWARS.Views;

public partial class DetallesPersonaje : ContentPage
{
	public DetallesPersonaje(clsPersonaje personajeRecibido, string nombrePlanetaRecibido)
	{
		InitializeComponent();
		BindingContext = new DetallesPersonajeVM(personajeRecibido, nombrePlanetaRecibido);
	}
}