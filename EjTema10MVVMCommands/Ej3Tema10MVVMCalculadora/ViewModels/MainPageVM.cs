using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ej3Tema10MVVMCalculadora.ViewModels.Utilidades;
using Microsoft.Extensions.Options;

namespace Ej3Tema10MVVMCalculadora.ViewModels
{
    //Heredo clsVmBase para notificar cambios a interfaz
    public class MainPageVM:clsVMBase
    {
        //lo que necesite de parametro para check o ejeccucion requiere de <string>
        #region atributos
        private DelegateCommand <string> operationCommand;
        private DelegateCommand <string> digitCommand; 
        private DelegateCommand backSpaceCommand;
        private DelegateCommand clearCommand; 
        private DelegateCommand resultCommand;
        private string entry;
        #endregion
        //binding parece funcionar porque muestra entry a valor asignado pero no parece recibir ningun click
        #region constructores
        public MainPageVM() {
                
            operationCommand = new DelegateCommand<string>(OperationCommandExecute);//añadir canExecute cuando funcione
            digitCommand = new DelegateCommand<string>(DigitCommandExecute);
            backSpaceCommand = new DelegateCommand(BackSpaceCommandExecute, OperationCommandCanExecute);
            clearCommand = new DelegateCommand(ClearCommandExecute);
            resultCommand = new DelegateCommand(ResultCommandExecute, OperationCommandCanExecute);
            entry = "0";
        }
        #endregion

        #region propiedades
        public DelegateCommand<string> OperationCommand { get; } 
        public DelegateCommand<string> DigitCommand { get; }
        public DelegateCommand BackSpaceCommand { get; }
        public DelegateCommand ClearCommand { get; }
        public DelegateCommand ResultCommand { get; } 
        //si entry es modificado se comprobaran los canExecute de los comandos que lo posean, set a privado para solo modif interna 
        public string Entry { get { return entry; } private set { entry = value; checkCanExecutes(); } }
        #endregion

        #region comandos
        /// <summary>
        /// check de ejecucion de doOperation, usa EntryEsValido con Entry y un patron como argumentos
        /// y en no es equals para comprobar que se puede añadir operador a entry
        /// </summary>
        /// <returns>devuelve bool doOperation para notificar permiso de ejecucion a execute</returns>
        public bool OperationCommandCanExecute()
        {
            bool doOperation = false;
            //formato para poder añadir signo operacion 
            string patron = @"^(?!.*[+\-%X]).*$"; 
            //si cumple patron es que no contiene operador y si ademas no es igual a 0. se puede añadir operador
            if (EntryEsValido(Entry, patron) && (!Entry.Equals("0.")) && (!Entry.Equals("0")))
            {
                doOperation = true;
            }
            return doOperation;
        }

        /// <summary>
        /// añade signo a cadena entry
        /// </summary>
        /// <param name="signo"></param>
        public void OperationCommandExecute(string signo)
        {
            if (OperationCommandCanExecute()) { 
            Entry += signo;
            NotifyPropertyChanged("Entry");
            }
          
        }

        /// <summary>
        /// añade digito a cadena entry en base a comprobaciones 
        /// </summary>
        /// <param name="digito"></param>
        public void DigitCommandExecute(string digito)
        {
            //int cosa = Entry.Count('.');
            // if (Entry.Count('.')<=2)
            Entry += digito;
            NotifyPropertyChanged("Entry");
        }

        /// <summary>
        /// check de ejecucion de backSpace si entry tiene valor diferente a 0 permite ejecucion de lo contrario no
        /// </summary>
        /// <returns>devuelve bool doBackSpace para notificar permiso de ejecucion a execute</returns>
        public bool BackSpaceCommandCanExecute()
        {
            bool doBackSpace = false;
            if (!Entry.Equals("0"))
            {
                doBackSpace = true;
            }
            return doBackSpace;
        }

        /// <summary>
        /// borrara un caracter del texto eliminando ultimo char de entry
        /// </summary>
        public void BackSpaceCommandExecute()
        {
            //elimina ultimo caracter de entry y asigna cadena obtenida a entry
            Entry = Entry.Substring(0, Entry.Length - 1);
            NotifyPropertyChanged("Entry");
        }

        /// <summary>
        /// "borrara" texto dando a entry valor igual a cadena con 0
        /// </summary>
        public void ClearCommandExecute()
        {
            Entry = "0";
            NotifyPropertyChanged("Entry");
        }

        /// <summary>
        /// check de ejecucion de doResult usa EntryEsValido con Entry y un patron como argumentos para comprobar que se puede obtener resultado operando
        /// </summary>
        /// <returns>devuelve bool doResult para notificar permiso de ejecucion a execute</returns>
        public bool ResultCommandCanExecute() 
        { 
            bool doResult = false;
            string patron = @"^[-]?\d+(\.\d+)?([-+X%])[-]?\d+(\.\d+)?$"; //formato para poder operar y devolver resultado

            if (EntryEsValido(Entry, patron))
            {
                doResult = true;
            }
            return doResult;
        }

        //TO DO
        public void ResultCommandExecute()
        {

        }

        #endregion

        #region metodos y funciones
        /// <summary>
        /// metodo que recibe el entry y un patron como cadenas, comprueba si entry tiene formato de patron 
        /// </summary>
        /// <param name="cadenaEntry"></param>
        /// <returns>devuelvo bool</returns>
        public bool EntryEsValido(string cadenaEntry, string patron)
        {
            bool valida = false;

            //instancia de objeto REGEX que sirve para comprobar formato de cadena en base a patron dado
            Regex regex = new Regex(patron);

            //devuelvo bool devuelto por metodo IsMatch de objeto regex con cadenaEntry como argumento 
            valida = regex.IsMatch(cadenaEntry);

            return valida;
        }

        public void checkCanExecutes()
        {
            operationCommand.RaiseCanExecuteChanged();
            backSpaceCommand.RaiseCanExecuteChanged();
            resultCommand.RaiseCanExecuteChanged();
        }
        #endregion

    }
}
