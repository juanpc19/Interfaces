namespace Solarizer.Views;

    public partial class Login : ContentPage
    {
    
        bool userCorrecto=false;//guardara introduccion de usuario correcta o incorrecta

        bool passCorrecto=false;//guardara introduccion de password correcta o incorrecta


    /// <summary>
    /// inicializa pagina Login 
    /// </summary>
    public Login()
        {
            InitializeComponent();
        //para iniciar la pagina sin la barra de navegacion superior
        NavigationPage.SetHasNavigationBar(this, false);
        //vuelvo los mensajes de error invisibles
            errorUser.Opacity = 0;
            errorPass.Opacity = 0;    
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
                errorUser.Opacity = 1;
                userCorrecto = false;
            }
            else
            {
                userCorrecto = true;
                errorUser.Opacity = 0;

            }

            if (string.IsNullOrEmpty(entryPass.Text))
            {
                errorPass.Opacity = 1;
                passCorrecto = false;

            } else
            {
                passCorrecto = true;
                errorPass.Opacity = 0;
            }
        //si los datos son correctos navego a Citas
        if (userCorrecto && passCorrecto)
            {
                Navigation.PushAsync(new Citas());
            }
        }


    }
