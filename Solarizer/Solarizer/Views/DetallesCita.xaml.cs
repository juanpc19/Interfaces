using Solarizer.Models;


namespace Solarizer.Views;

public partial class DetallesCita : ContentPage
{

    //lineas para trastear con pasar una cita de la lista a esta pagina
    //tabbeb page: geo loc, camara, edit nota observac
    //y aqui pasarle la cita en param entrada
    //private clsCita cita;
    //clsCita cita2
    //cita = cita2;

    public DetallesCita()
	{
		InitializeComponent();
        //para iniciar la pagina sin la barra de navegacion superior
        NavigationPage.SetHasNavigationBar(this, false);

    }

    /// <summary>
    /// funcion para navegar atras hacia listado al pulsar boton correspondiente
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        public void VolverListadoCitas(object sender, EventArgs e)
    {
        //hago un push en lugar de pop para evitar bloque de click en mismo contacto de lista (con datos necesitaria pop?)
        Navigation.PushAsync(new Citas());
    }

    /// <summary>
    /// simula guardar nota en click en boton mostrando mensaje popup y reiniciando valor de text del editor
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void GuardarNota(object sender, EventArgs e)
    {
        await DisplayAlert("Notificación", "Nota Guardada", "OK");
        notasCita.Text = "";

    }
    /// <summary>
    /// simula guardar cita en click en boton mostrando mensaje popup 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void GuardarCita(object sender, EventArgs e)
    {
        await DisplayAlert("Notificación", "Datos de cita guardados", "OK");
    }

    /// <summary>
    /// funcion que tomara una foto simulara hacerlo (no consigo hacerla funcionar)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void TomarFoto(object sender, EventArgs e)
    {
        try
        {
            var foto = await MediaPicker.CapturePhotoAsync();
            Console.WriteLine("Foto hecha!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al hacer la foto: {ex.Message}");
        }
    }

    /// <summary>
    /// funcion para añadir imagen existente de la galeria a la cita
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AñadirFotoGaleria(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// funcion para abrir la navegacion gps hasta la direccion de la cita
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GeoLocalizacion(object sender, EventArgs e)
    {

    }
}