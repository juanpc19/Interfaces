using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMaui.CapaBL.Listados;
using UIMaui.Models;
using UIMaui.ViewModels.Utilidades;

namespace UIMaui.ViewModels
{
    public class JuegoVM : clsVMBase
    {
        #region atributos

        private int intentosRestantes;

        private int aciertos;

        private DelegateCommand comprobarCommand;

        private ObservableCollection<clsPersonaConListaDep> listaPersonasConListaDep;
        #endregion

        #region constructores
        /// <summary>
        /// constructor que llamara a recogerListado para recoger datos de api y asignarlos a listaPersonasConListaDep
        /// </summary>
        public JuegoVM()
        {
            listaPersonasConListaDep = new ObservableCollection<clsPersonaConListaDep>();
            RecogerListado();
            intentosRestantes = 3;
            aciertos = 0;
            comprobarCommand = new DelegateCommand(ComprobarCommandExecute);
        }
        #endregion

        #region propiedades
        public int IntentosRestantes
        {
            get { return intentosRestantes; }
        }
        public int Aciertos
        {
            get { return aciertos; }
        }

        public DelegateCommand ComprobarCommand
        {
            get { return comprobarCommand; }
        }

        public ObservableCollection<clsPersonaConListaDep> ListaPersonasConListaDep
        {
            get { return listaPersonasConListaDep; }
        }
        #endregion


        #region comandos

        //comprobara si se puede ejecutar el comando comprobar recorriendo la lista de listaPersonaConListaDep
        //comprobando que todos los elementos tienen depseleccinados
        //NO SE DONDE NOTIFICAR EL RAISECANEXECUTECHANGED ASI QUE HABILITO EL EJECUTAR Y DEJO ESTO "SIN USAR"
        //private bool ComprobarCommandCanExecute()
        //{
        //    bool ejecutable = true;

        //    foreach (clsPersonaConListaDep oPersona in listaPersonasConListaDep)
        //    {
        //        if (oPersona.DepartamentoSeleccionado.Id == 0)
        //        {
        //            ejecutable = false;
        //        }
        //    }

        //    return ejecutable;
        //}

        /// <summary>
        /// realizara comprobacion de deps seleccionados para cada persona en la lista con lo que establecera valores para aciertos y intentos restantes
        /// </summary>
        private async void ComprobarCommandExecute()
        {
            aciertos = 0;//reinicio aciertos cada vez que compruebo pulsando el boton

            //recorro lista de personas con deps seleccionados y compruebo si son correctos si son iguales a idDep de persona contenida en personaConListaDep
            foreach (clsPersonaConListaDep oPersona in listaPersonasConListaDep)
            {
                if (oPersona.DepartamentoSeleccionado.Id == oPersona.Persona.IdDepartamento)
                {
                    aciertos++;//sumo los aciertos pertinentes
                }
            }

            intentosRestantes--; //resto un intento cada vez que compruebo

            NotifyPropertyChanged("IntentosRestantes");//notifico cambio en intentos restantes
            NotifyPropertyChanged("Aciertos");//notifico cambio en aciertos

            if (intentosRestantes == 0 || aciertos == listaPersonasConListaDep.Count()) //si se acaban los intentos o se acierta todo compruebo resultado
            {
                ComprobarResultado();
            }

        }

        #endregion

        #region metodos
        /// <summary>
        /// funcion que recorrera listaPersonasConListaDep dandole valores extraidos de api a traves de capa bl
        /// </summary>
        private async void RecogerListado()
        {
            //recogo datos de api y los asigno a listadoPersonas
            clsListaPersonasBL oListaPersonasBL = new clsListaPersonasBL();
            List<clsPersona> listadoPersonas = await oListaPersonasBL.ListadoPersonasBL();

            //recogo datos de api y los asigno a listadoDepartamentos
            clsListaDepartamentosBL oListaDepartamentosBL = new clsListaDepartamentosBL();
            List<clsDepartamento> listadoDepartamentos = await oListaDepartamentosBL.ListadoDepsBL();

            clsPersona persona;//declaro persona para darle valores en bucle y usarla en constructor de oPersonaConListaDep

            for (int i = 0; i < listadoPersonas.Count; i++)
            {
                persona = listadoPersonas[i];//le doy a persona valor actual de i lista personas 
                //instancio oPersonaConListaDep con persona actual y listadoDepartamentos como param entrada
                clsPersonaConListaDep oPersonaConListaDep = new clsPersonaConListaDep(persona, listadoDepartamentos);
                listaPersonasConListaDep.Add(oPersonaConListaDep);//la añado a la lista
            }
            //compruebo si el comnado comprobar puede ejecutarse al cargar elementos del listado(spoiler no puede porque esta recien cargado)
            //comprobarCommand.RaiseCanExecuteChanged();
        }
        #endregion

        /// <summary>
        /// comprobara el resultado del juego y mostrara mensaje de victoria o derrota dando opcion al jugador de jugar de nuevo o no
        /// </summary>
        private async void ComprobarResultado()
        {
            bool jugarDeNuevo = true;//guarda decision jugador

            if (aciertos == listaPersonasConListaDep.Count())//si aciertos es igual a numero de personas en lista se han acertado todos
            {
                jugarDeNuevo = await App.Current.MainPage.DisplayAlert("Has ganado!", "¿Deseas jugar de nuevo?", "SI", "NO");//recojo respuesta jugador en caso victoria

            }
            //de lo contrario se ha llamdo a la funcion porque se han acabado los intentos asi que  ha perdido
            else
            {
                jugarDeNuevo = await App.Current.MainPage.DisplayAlert("Has perdido!", "¿Deseas jugar de nuevo?", "SI", "NO");//recojo respuesta jugador en caso derrota
            }

            //evaluo respuesta jugador para reiniciar juego o cerrar aplicacion,
            //si quiere seguir jugando
            if (jugarDeNuevo)
            {
                //vacio la lista con .clear y la recargo con recogerListado para que los dep seleccionados vuelvan a estar default 
                listaPersonasConListaDep.Clear();
                RecogerListado();
                NotifyPropertyChanged("ListaPersonasConListaDep");//notifica el cambio en la lista
                //y reinicio el numero de intentos
                intentosRestantes = 3;
                NotifyPropertyChanged("IntentosRestantes");//notifico cambio en intentos restantes
                //y el numero de aciertos
                aciertos = 0;
                NotifyPropertyChanged("Aciertos");//notifico cambio en aciertos
            }
            else
            {
                //si no quiere seguir jugando cierro la aplicacicon
                App.Current.Quit();
            }

        }
    }
}
