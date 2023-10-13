namespace Ej4Tema5Calendarios
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //metodo llamado al pulsar botonUpdate que actualizara el calendario
        public void actualizarCalendario(object sender, EventArgs e)
        {
            // coge fecha
            DateTime diaActual = DateTime.Now;
            // coge dia actual de objeto fecha
            int hoy = diaActual.Day;

            //recorro los botones/dias del mes
            for (int i = 1; i <=31; i++)
            {
                //creo variable que usare para localizar el id del boton
                string nombreBoton = "button" + i.ToString();
                //creo variable button que guardara localizacion de boton actual una vez lo encuentre con
                //FindByName que buscara un elemento tipo Button con id igual a nombreBoton
                var button=this.FindByName<Button>(nombreBoton);

                //asigno texto de boton/dia correspondiente a iteracion actual en variable diaBucle
                int diaBucle = int.Parse(button.Text);

                //si el diaBucle actual es menor a hoy
                if (diaBucle < hoy) 
                {
                    //lo pondra de color gris indicando dia no disponible
                     button.BackgroundColor = Color.FromRgb(169, 169, 169);
                }
               
            }
                
        }

        //metodo llamado AL PULSAR ENTER O DONE EN EL TECLADO (solo con escribir no funciona) que actualizara el calendario 2
        public void actualizarCalendario2(object sender, EventArgs e)
        {
            //creo variable entry que guardara localizacion de diaSalida una vez lo encuentre con
            //FindByName que buscara un elemento tipo Entry con id igual a diaSalida
            var entry = this.FindByName<Entry>("diaSalida");
            //inicio diaSalida a 0 para comprobacion en if
            int diaSalida = 0;

            //compruebo que el campo text del entry no es nulo y esta en rango de 1 a 31 
            if (entry.Text != null && int.Parse(entry.Text)<32 && int.Parse(entry.Text)>0)
            {
                //si la comprobacion va bien guardo en variable el texto del entry
                diaSalida = int.Parse(entry.Text);
                //recorro los botones/dias del mes
                for (int i = 1; i <= 31; i++)
                {
                    //creo variable que usare para localizar el id del boton
                    string nombreBoton = "boton" + i.ToString();
                    //creo variable button que guardara localizacion de boton actual una vez lo encuentre con
                    //FindByName que buscara un elemento tipo Button con id igual a nombreBoton
                    var button = this.FindByName<Button>(nombreBoton);

                    //asigno texto de boton/dia correspondiente a iteracion actual en variable diaBucle
                    int diaBucle = int.Parse(button.Text);

                    //si el diaBucle actual es menor a diaSalida
                    if (diaBucle < diaSalida)
                    {
                        //lo pondra de color gris indicando dia no disponible
                        button.BackgroundColor = Color.FromRgb(169, 169, 169);
                    }

                }
            } 
           

            

        }



    }
}