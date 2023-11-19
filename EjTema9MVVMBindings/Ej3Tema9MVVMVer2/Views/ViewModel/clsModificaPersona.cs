        using BibliotecaDeClases;//no se usa?
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Ej3Tema9MVVMVer2.Views.ViewModel
{
    public class clsModificaPersona : INotifyPropertyChanged
    {

        #region atributos
        public event PropertyChangedEventHandler PropertyChanged;

        private string nombre;
        #endregion

        #region constructores
        /// <summary>
        /// constructor por defecto con valor dafault
        /// </summary>
        public clsModificaPersona()
        {
            nombre = "cosa";

        }
        /// <summary>
        /// constructor con parametro entrada
        /// </summary>
        /// <param name="nombre"></param>
        public clsModificaPersona(string nombre)
        {
            this.nombre = nombre;

        }
        #endregion

        #region propiedades
        //modifico nombre de propiedad de clsModificaPersona a NombreM para claridad
        public string NombreM
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(); }
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
