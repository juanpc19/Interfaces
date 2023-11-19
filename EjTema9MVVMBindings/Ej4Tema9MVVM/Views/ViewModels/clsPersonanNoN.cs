using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
 

namespace Ej4Tema9MVVM.Views.ViewModels
{
    internal class clsPersonanNoN : INotifyPropertyChanged
    {
        #region atributos
        public event PropertyChangedEventHandler PropertyChanged;
        private string nombre;
        private string apellidos;
        #endregion

        #region constructores
        public clsPersonanNoN()
        {
            nombre = "cosa";
            apellidos = "de cosa";
        }

        public clsPersonanNoN(string nombre, string apellidos) {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {
               //da valor a nombre
                nombre = value; 
                //comprobacion de si nombre contiene letra n
                if (nombre.Contains("n"))
                {
                    //de contenerla cambio contenido apellidos a string vacia
                    apellidos = string.Empty;
                }
                //notifica a UI que QUIZAS se ha dado un cambio en apellidos, lo cual fuerza check y de haber cambio lo muestra en pantalla
                OnPropertyChanged("Apellidos"); }
        }

        //igual pero inverso para set de Apellidos
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value;
                if (apellidos.Contains("n"))
                {
                    nombre=string.Empty;
                }
                OnPropertyChanged("Nombre"); }
        }
        #endregion

        #region metodos
        public void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        #endregion



    }
}
