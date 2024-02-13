using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMaui.CapaBL.Listados;
using UIMaui.ViewModels.Utilidades;

namespace UIMaui.ViewModels
{
    public class JuegoVM: clsVMBase
    {
        #region atributos
        private int tiradasHechas;

        private string aciertos;

        private string errores;

        private DelegateCommand comprobarCommand;

        private clsDepartamento depSeleccionado;

        private ObservableCollection<clsPersonaConListaDep> listaPersonaConListaDep;
        #endregion

        #region constructores
        public JuegoVM()
        {
            tiradasHechas = 0;
            aciertos = string.Empty;
            errores = string.Empty;
            comprobarCommand = new DelegateCommand (ComprobarCommandExecute, ComprobarCommandCanExecute);
            listaPersonaConListaDep = new ObservableCollection<clsPersonaConListaDep> ();
            RecogerListado();
        }
        #endregion


        #region propiedades
        public int TiradasHechas
        {
            get { return tiradasHechas; }
            set { tiradasHechas = value; }
        }
        public string Aciertos
        {
            get { return aciertos; } set { aciertos = value; }
        }

        public string Errores
        {
            get { return errores; } set { errores = value; }    
        }

        public DelegateCommand ComprobarCommand
        { 
            get { return comprobarCommand; }
        }

        public ObservableCollection<clsPersonaConListaDep> ListaPersonaConListaDep
        {
            get { return listaPersonaConListaDep; } private set { listaPersonaConListaDep = value; }
        }
        #endregion


        #region comandos

        //comprobara si se puede ejecutar el comando comprobar recorriendo la lista de listaPersonaConListaDep comprobando que todos los elementos estan seleccinados
        private bool ComprobarCommandCanExecute()
        {
            bool faltanDeps = false;

            for (int i = 0; i < listaPersonaConListaDep.Count; i++)
            {
                clsPersona persona = new clsPersona();
                persona = listaPersonaConListaDep[i].Persona;
                //necesito dep seleccionado?
                if (depSeleccionado == null && TiradasHechas<3)
                {
                    faltanDeps = true;
                } 
            }
          
            return faltanDeps;
        }

        //realizara comprobacion de deps seleccionados para cada persona en la lista estableciendo valores para aciertos y errores
        private async void ComprobarCommandExecute()
        {
            //logica de compraobar dep seleccionado de personas igual a idDep

            //ir actualizando aciertos y errores en cada click

            //si tiradas hechas==3 preguntar 
            //   await DisplayAlert("Notificación", "desea jugar de nuevo", "SI", "NO");

            //si respnde si recargar pagina

            //de lo contrario 
            //Application.Current.Quit();
        }

        #endregion

        #region metodos
        //funcion que recorrera listaPersonaConListaDep dandole valores extraidos de apia  traves de capa bl
        private async void RecogerListado()
        {
           
            //recoger datos lista personas y list dep y pasar datos a listaPersonaConListaDep
            clsListaPersonasBL oBL = new clsListaPersonasBL();
            List<clsPersona> listadoPersonas = await oBL.ListadoPersonasBL();


            clsListaDepartamentosBL oBl = new clsListaDepartamentosBL();
            List<clsDepartamento> listaDeps = await oBl.ListadoDepsBL();
           
            clsPersona persona= new clsPersona();

            clsPersonaConListaDep oPersonaConListaDep = new clsPersonaConListaDep();

            for (int i = 0; i < listadoPersonas.Count; i++)
            {
                //ME DA ERROR AQUI carga la lista de personas pero da erorr al cargar lista de departamentos
                persona=listadoPersonas[i];
                //listaPersonaConListaDep[i].Persona = persona;
                // listaPersonaConListaDep[i].ListaDepartamentos = listaDeps;
                oPersonaConListaDep.Persona= persona;
                oPersonaConListaDep.ListaDepartamentos = listaDeps;
                listaPersonaConListaDep.Add(oPersonaConListaDep);
             }
        }
        
       
        #endregion


    }
}
