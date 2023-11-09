namespace ExamenInterfacesJuanPerezCaballero
{
    public partial class MainPage : ContentPage
    {
        int cuentaErrores = 0; //contara los errores
        int cuentaAciertos = 0; //contara los aciertos

        /// <summary>
        /// inicializo la pagina con mensajes y botones tanto de aciertos como de decision de otra partida ocultos
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            boton1.Opacity = 0;
            boton2.Opacity = 0;
            boton3.Opacity = 0;
            boton4.Opacity = 0;
            boton5.Opacity = 0;
            boton6.Opacity = 0;
            derrota.Opacity = 0;
            victoria.Opacity = 0;
            botonSi.Opacity = 0;
            botonNo.Opacity = 0;
            
        }

       
        /// <summary>
        /// cuanta clicks en lugares que no son 1 de las 3 diferencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            //en click sumo valor a cuentaErrores
            cuentaErrores++;

            //actualizo mensaje muestra errores
            cuentaClicks.Text = $"Fallos actuales {cuentaErrores} ";

            //si es el 3 fallo 
            if (cuentaErrores == 3)
            {
                //muestro mensaje de derrota y pregunto si quiere jugar otra partida mostrando 2 botones para ello
                derrota.Opacity = 1;
                botonSi.Opacity = 1;
                botonNo.Opacity = 1;
                //retiro mensajes innecesarios
                bienvenida.Opacity = 0;
                cuentaClicks.Opacity = 0;
            }
            

          
         
        }
        /// <summary>
        /// revela botones 1 y 4 si el click es en el lugar donde hay 1 diferencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCorrecto(object sender, EventArgs e)
        {
            //en click en lugar correcto sumo valor a cuentaAciertos y dejo los botones a la vista
            boton1.Opacity = 1;
            boton4.Opacity = 1;
            cuentaAciertos += 1;

          //si es el 3 acierto 
            if (cuentaAciertos == 3)
            {
                //muestro mensaje de victoria y pregunto si quiere jugar otra partida mostrando 2 botones para ello
                victoria.Opacity = 1;
                botonSi.Opacity = 1;
                botonNo.Opacity = 1;
                //retiro mensajes innecesarios
                bienvenida.Opacity = 0;
                cuentaClicks.Opacity = 0;
            }

        }
        /// <summary>
        /// revela botones 2 y 5 si el click es en el lugar donde hay 1 diferencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCorrecto2(object sender, EventArgs e)
        {
            //en click en lugar correcto sumo valor a cuentaAciertos y dejo los botones a la vista
            boton2.Opacity = 1;
            boton5.Opacity = 1;
            cuentaAciertos += 1;

            //si es el 3 acierto
            if (cuentaAciertos == 3)
            {
                //muestro mensaje de victoria y pregunto si quiere jugar otra partida mostrando 2 botones para ello
                victoria.Opacity = 1;
                botonSi.Opacity = 1;
                botonNo.Opacity = 1;
                //retiro mensajes innecesarios
                bienvenida.Opacity = 0;
                cuentaClicks.Opacity = 0;
            }

        }
        /// <summary>
        /// revela botones 3 y 6 si el click es en el lugar donde hay 1 diferencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCorrecto3(object sender, EventArgs e)
        {
            //en click en lugar correcto sumo valor a cuentaAciertos y dejo los botones a la vista
            boton3.Opacity = 1;
            boton6.Opacity = 1;
            cuentaAciertos += 1;

            //si es el 3 acierto
            if (cuentaAciertos==3)
            {
                //muestro mensaje de victoria y pregunto si quiere jugar otra partida mostrando 2 botones para ello
                victoria.Opacity = 1;
                botonSi.Opacity = 1;
                botonNo.Opacity = 1;
                //retiro mensajes innecesarios
                bienvenida.Opacity = 0;
                cuentaClicks.Opacity = 0;
            }

        }

        /// <summary>
        /// si se pulsa si para jugar otra partida recargara la pagina para empezar la nueva partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otraPartida(object sender, EventArgs e)
        {
            //hago un push a una nueva main page 
            Navigation.PushAsync(new MainPage());
            
        }

        /// <summary>
        /// si se pulsa boton no se cerrara la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitar(object sender, EventArgs e)
        {
            //cierro la aplicacion 
            Application.Current.Quit();
        }

    }
}