namespace Solarizer.Views;

    public partial class Login : ContentPage
    {
      //NAV BAR VISIBLE TO FALSE 
        bool userCorrecto=false;//guardara introduccion de usuario correcta o incorrecta

        bool passCorrecto=false;//guardara introduccion de password correcta o incorrecta


    /// <summary>
    /// inicializa pagina Login 
    /// </summary>
    public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        //vuelvo los mensajes de error invisibles
            errorUser.IsVisible = false;
            errorPass.IsVisible = false;    
        }

    /// <summary>
    /// metodo que permitira navegacion a pagina Citas si se han introducido datos o mostrara mensajes de error en caso contrario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        public void InicioSesion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryUser.Text))
            {
                errorUser.IsVisible = true;
                userCorrecto = false;
            }
            else
            {
                userCorrecto = true;
                errorUser.IsVisible = false;

            }

            if (string.IsNullOrEmpty(entryPass.Text))
            {
                errorPass.IsVisible = true;
                passCorrecto = false;

            } else
            {
                passCorrecto = true;
                errorPass.IsVisible = false;
            }
        //si los datos son correctos navego a Citas
        if (userCorrecto && passCorrecto)
            {
                Navigation.PushAsync(new Citas());
            }
        }


    }
