using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Ej6Tema8Layouts
{
    //falta el delete
    public partial class MainPage : ContentPage
    {
        //instancio fecha aqui para usar en add y save
        DateTime currentDate = DateTime.Now;

        //check de botones creados creo aqui para uso en multiples metodos
        bool botonesCreados=false;

        //declaro los botones aqui para poder usarlos en el metodo DeleteClicked y en ClickYes y ClickNo
        //(necesario porque si los creo en el delete no existen en los otros por lo que no puedo usarlos hasta creacion
        Button buttonYes;
        Button buttonNo;

        /// <summary>
        /// metodo que inicializara la pagina con visibilidad de labels con mensaje
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            mensajeErrorNombre.IsVisible = false;
            mensajeErrorApellidos.IsVisible = false;
            mensajeErrorFecha.IsVisible = false;
            mensajeTodoCorrecto.IsVisible = false;
            mensajeBorrado.IsVisible = false;
            confirmacionBorrar.IsVisible = false;
        }

        /// <summary>
        /// metodo que reiniciara valores de elementos y volvera mensajes invisibles cambiando la visibilidad de los labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddClicked(object sender, EventArgs e)
        {
            entryNombre.Text = null; //reinicio texto a null
            entryApellidos.Text = null; //reinicio texto a null
            fechaNacimiento.Date = currentDate; //le cambia el formato a mes/dia/año pero resetea en click

            //cambio la visibilidad de los labels para ocultarlos
            mensajeErrorNombre.IsVisible = false;
            mensajeErrorApellidos.IsVisible = false;
            mensajeErrorFecha.IsVisible = false;
            mensajeTodoCorrecto.IsVisible = false;
            mensajeBorrado.IsVisible = false;
            confirmacionBorrar.IsVisible = false;

            //llamo a metodo noclick para borrar botones 
            NoClick(sender, e);
        }
   
        /// <summary>
        /// metodo que mostrara mensajes de error o correcto tras varias comprobaciones de datos introducidos por usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaveClicked(object sender, EventArgs e)
        {
            //variables para controlar la correcta introduccion de datos
            bool nombreCorrecto = false;
            bool apellidosCorrecto = false;
            bool fechaNacimientoCorrecto = false;
           
            //llamo a metodo noclick para borrar botones 
            NoClick(sender,e);
            //y quito visibilidad de label mensaje de borrado y confirmacion borrar en caso de que el boton delete
            //haya sido usado previamente a pulsar save no puedo usar el add porque borraria campos
            confirmacionBorrar.IsVisible = false;
            mensajeBorrado.IsVisible = false;

            //y quito visibilidad de label mensajeTodoCorrecto en caso de que el boton save
            //haya sido usado previamente a pulsar save no puedo usar el add porque borraria campos
            mensajeTodoCorrecto.IsVisible=false;

            //si el nombre es introducido correctamente
            if (!string.IsNullOrEmpty(entryNombre.Text))
            {
                nombreCorrecto=true;
                //oculto mensaje cambiando la visibilidad del label
                mensajeErrorNombre.IsVisible = false;
            } else {
                //muestro mensaje comunicando el guardado erroneo cambiando la visibilidad del label
                mensajeErrorNombre.IsVisible = true;
            }

            //si los apellidos son introducidos correctamente
            if (!string.IsNullOrEmpty(entryApellidos.Text))
            {
                apellidosCorrecto = true;
                //oculto mensaje cambiando la visibilidad del label
                mensajeErrorApellidos.IsVisible = false;
            } else {
                //muestro mensaje comunicando el guardado erroneo cambiando la visibilidad del label
                mensajeErrorApellidos.IsVisible = true;
            }

            //si la fecha de nacimiento es introducido correctamente
            if (fechaNacimiento != null && fechaNacimiento.Date <= currentDate)
            {
                fechaNacimientoCorrecto = true;
                //oculto mensaje cambiando la visibilidad del label
                mensajeErrorFecha.IsVisible = false;
            } else {
                //muestro mensaje comunicando el guardado erroneo cambiando la visibilidad del label
                mensajeErrorFecha.IsVisible = true;
            }

            //si todos los datos son introducidos correctamente
            if (nombreCorrecto && apellidosCorrecto && fechaNacimientoCorrecto)
            {
                //muestro mensaje comunicando el guardado exitoso cambiando la visibilidad del label
                mensajeTodoCorrecto.IsVisible = true;
            } 
        }

        /// <summary>
        /// metodo que creara dos botones en caso de que no existan añadiendoles eventos on click y añadiendolos al layout horizontal inferior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteClicked(object sender, EventArgs e)
        {

            //oculto mensaje de guardado para no manterlo en pantalla de forma innecesaria
            mensajeTodoCorrecto.IsVisible=false;

            //hago lo mismo con mensaje borrado para no manterlo en pantalla de forma innecesaria
            mensajeBorrado.IsVisible = false;
            confirmacionBorrar.IsVisible = true;

            //si no se han creado botones
            if (botonesCreados == false)
            {
                //creo boton yes
                buttonYes = new Button
                {
                    Text = "SI",
                    Background = Colors.Green,
                    BorderColor = Colors.Orange,
                    BorderWidth = 3,
                    CornerRadius = 30,
                    WidthRequest = 80,
                    HeightRequest = 80,
                };

                //creo boton no
                buttonNo = new Button
                {
                    Text = "NO",
                    Background = Colors.Red,
                    BorderColor = Colors.Orange,
                    BorderWidth = 3,
                    CornerRadius = 30,
                    WidthRequest = 80,
                    HeightRequest = 80,        
                };
                //añado metodos on click
                buttonYes.Clicked += new EventHandler(YesClick);
                buttonNo.Clicked += new EventHandler(NoClick);

                //añado botones al layout
                hsl.Children.Add(buttonYes);
                hsl.Children.Add(buttonNo);
                //modifico estado botonesCreados
                botonesCreados = true;
            }
        }

        /// <summary>
        /// metodo que borrara botones del layout, reiniciara valores del formulario llamando a metodo AddClicked y 
        /// mostrara mensaje de borrado, modificando ademas el estado de creacion de los botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void YesClick (object sender, EventArgs e)
        {
            hsl.Children.Remove(buttonYes);
            hsl.Children.Remove(buttonNo);
            AddClicked(sender, e);
            mensajeBorrado.IsVisible = true;
            botonesCreados = false;
        }

        /// <summary>
        /// metodo que borrara botones del layout, modificara el estado de creacion de los botones y quitara mensaje confirmacionBorrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NoClick (object sender, EventArgs e)
        {
            hsl.Children.Remove(buttonYes);
            hsl.Children.Remove(buttonNo);
            botonesCreados = false;
            confirmacionBorrar.IsVisible = false;
        }
}
}