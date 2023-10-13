using System.Diagnostics;

namespace Ej2Tema5Controles
{
    public partial class MainPageOtra : ContentPage
    {
        public MainPageOtra()
        {
            InitializeComponent();
        }
        private void OnClick(object sender, EventArgs e)
        {

            // MainPage mainPageOtra = new MainPage();
            // await Navigation.PushAsync(mainPageOtra);
            Navigation.PushAsync(new MainPage());

           

        }

        private void boton_Clicked(object sender, EventArgs e)
        {

        }
    }
}