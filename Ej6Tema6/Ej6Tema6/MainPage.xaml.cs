using Microsoft.Maui.Controls;

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
            if (botonCreado==false)
            {
                Button boton3 = new Button
                {
                    Text = "Boton3",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.FromHex("#FF0000FF"),
                    HeightRequest = 70,
                    WidthRequest = 200,
                    FontFamily = "Verdana",
                    FontAttributes = FontAttributes.Bold,
                    BorderColor = Color.FromHex("#FFFF00"),
                    Margin = 30

                };

                (vsl).Children.Add(boton3);
                botonCreado = true;
                (vsl).Children.Remove(Boton1);
                Boton2.Text = "Crear controles en tiempo de ejecución mola";
            }
           


        }
       
    }
}