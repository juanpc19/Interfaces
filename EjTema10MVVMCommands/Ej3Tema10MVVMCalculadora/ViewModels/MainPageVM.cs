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
        #region atributos
        private DelegateCommand operationCommand;
        private DelegateCommand digitCommand; //no necesita comprobacion si tengo 0 entry=string si tengo otra cosa: numero, 0., o . añado entry+=string
        private DelegateCommand backSpaceCommand;
        private DelegateCommand clearCommand; //SE EJECUTA SIEMPRE no necesita canExecute pone entry a 0
        private DelegateCommand resultCommand;
        private string entry;
        #endregion

        #region constructores
        public MainPageVM() {
            operationCommand = new DelegateCommand(OperationCommandExecute, OperationCommandCanExecute);
            digitCommand = new DelegateCommand(DigitCommandExecute);
            backSpaceCommand = new DelegateCommand(BackSpaceCommandExecute, OperationCommandCanExecute);
            clearCommand = new DelegateCommand(ClearCommandExecute);
            resultCommand = new DelegateCommand(ResultCommandExecute, OperationCommandCanExecute);
            entry = "0";
        }
        #endregion

        #region propiedades
        public DelegateCommand <string> OperationCommand { get; } 
        public DelegateCommand <string> DigitCommand { get; }
        public DelegateCommand <string> BackSpaceCommand { get; }
        public DelegateCommand <string> ClearCommand { get; }
        public DelegateCommand <string> ResultCommand { get; } 
        public string Entry { get { return entry; } private set { entry = value; } }
        #endregion

        #region comandos
        /// <summary>
        /// check de ejecucion de doOperation, usa EntryEsValido con Entry y un patron como argumentos
        /// y en no es equals para comprobar que se puede añadir operador a entry
        /// </summary>
        /// <returns>devuelve bool doOperation para notificar permiso de ejecucion a execute</returns>
        private bool OperationCommandCanExecute()
        {
            bool doOperation = false;
            string patron = @"^(?!.*[+\-%X]).*$"; //formato para poder añadir signo operacion
            //si cumple patron es que no contiene operador y si ademas no es igual a 0. se puede añadir operador
            if (EntryEsValido(Entry, patron) && (!Entry.Equals("0.")))
            {
                doOperation = true;
            }
            return doOperation;
        }

        private void OperationCommandExecute()
        {

        }

        private void DigitCommandExecute()
        {

        }

        /// <summary>
        /// check de ejecucion de backSpace si entry tiene valor diferente a 0 permite ejecucion de lo contrario no
        /// </summary>
        /// <returns>devuelve bool doBackSpace para notificar permiso de ejecucion a execute</returns>
        private bool BackSpaceCommandCanExecute()
        {
            bool doBackSpace = false;
            if (!Entry.Equals("0"))
            {
                doBackSpace = true;
            }
            return doBackSpace;
        }

        private void BackSpaceCommandExecute()
        {

        }

        private void ClearCommandExecute()
        {

        }

        /// <summary>
        /// check de ejecucion de doResult usa EntryEsValido con Entry y un patron como argumentos para comprobar que se puede obtener resultado operando
        /// </summary>
        /// <returns>devuelve bool doResult para notificar permiso de ejecucion a execute</returns>
        private bool ResultCommandCanExecute() 
        { 
            bool doResult = false;
            string patron = @"^[-]?\d+(\.\d+)?([-+X%])[-]?\d+(\.\d+)?$"; //formato para poder operar y devolver resultado

            if (EntryEsValido(Entry, patron))
            {
                doResult = true;
            }
            return doResult;
        }

        private void ResultCommandExecute()
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
        #endregion

    }
}
