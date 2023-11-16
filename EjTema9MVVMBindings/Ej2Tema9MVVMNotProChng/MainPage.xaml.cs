using Ej1Tema7.Models.Entidades;

namespace Ej2Tema9MVVMNotProChng
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new clsPersona();
        }
		//en este caso es aceptable situar clase persona en carpeta model porque el proyecto es pequeño
        //y facilita el uso de la interfaz INotifyPropertyChange,
        //en proyectos de mayor enveradura lo correcto seria ponerla en la carpeta ViewModel, dentro de Views?
	}
}