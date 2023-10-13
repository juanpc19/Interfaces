namespace Ej6Tema6
{
    public partial class MainPage : ContentPage
    {
        private bool botonCreado = false;
        public MainPage()
        {
            InitializeComponent();
        }

        private void CreaBoton3(object sender, EventArgs e)
        {

            Button boton3 = new Button
            {
                Text = "Boton3",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor =Color.FromHex("#FF0000FF"),
                

            };
        }
    }
}