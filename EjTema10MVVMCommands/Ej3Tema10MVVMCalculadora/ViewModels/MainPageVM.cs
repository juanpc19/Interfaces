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
    public class MainPageVM : clsVMBase
    {
       
        #region atributos
        private string entry;
        #endregion

        //lo que necesite de parametro para check o ejecucion requiere de <string> u otro parametro indicado
        public MainPageVM()
        { 
            DigitCommand = new DelegateCommand<string>(DigitCommandExecute);
            BackSpaceCommand = new DelegateCommand(BackSpaceCommandExecute, BackSpaceCommandCanExecute);
            ClearCommand = new DelegateCommand(ClearCommandExecute);
            ResultCommand = new DelegateCommand(ResultCommandExecute, ResultCommandCanExecute);
            entry = "0";
        }
        #region propiedades
         
        public DelegateCommand<string> DigitCommand { get; }
        public DelegateCommand BackSpaceCommand { get; }
        public DelegateCommand ClearCommand { get; }
        public DelegateCommand ResultCommand { get; }
        //si entry es modificado se comprobaran los canExecute de los comandos que lo posean, set a privado para solo modif interna 
        public string Entry { get { return entry; } private set { entry = value; checkCanExecutes(); } }
        #endregion
        #region constructores
       
        #endregion

        #region comandos
        /// <summary>
        /// añade digito a cadena entry en base a tipo digito devuelto por analizaDigito
        /// </summary>
        /// <param name="digito"></param>
        public void DigitCommandExecute(string digito)
        {
            string tipoDigito=AnalizaDigito(digito);
           
            switch (tipoDigito)
            {
                case "operador" when PermisoAñadirOperador(): 
                        Entry += digito; break;
            
                case "punto" when PermisoAñadirPunto():
                    Entry += digito; break;


                case "numero" when Entry.Equals("0"):
                    Entry = digito; break;

                case "numero" when !Entry.Equals("0"):
                    Entry += digito; break;
            }
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
        /// borrara un caracter del texto eliminando ultimo char de entry mientras entry no este vacio
        /// </summary>
        public void BackSpaceCommandExecute()
        {
            //elimina ultimo caracter de entry y asigna cadena obtenida a entry
            Entry = Entry.Substring(0, Entry.Length - 1);
            //si tras borrar es cadena vacia pone 0
            if (Entry.Equals(""))
            {
                Entry = "0";
            }
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
        /// check de ejecucion de Result devolvera true si entry contiene operador false en caso contrario
        /// </summary>
        /// <returns>devuelve bool permiso para notificar permiso de ejecucion a execute</returns>
        public bool ResultCommandCanExecute()
        {
            bool permiso = false;
            int cuentaOperadores = 0;//cuenta operadores actuales en entry para evitar break en foreach
            List<string> caracteresPermitenResult = new List<string> { "+", "-", "X", "%" };

            foreach (string c in caracteresPermitenResult)
            {
                if (Entry.Contains(c))
                {
                     cuentaOperadores += 1;
                }
            }
            if (cuentaOperadores > 0)
            {
                permiso = true;
            }
           

            return permiso;
        }

        /// <summary>
        /// funcion que extraera datos de string en una lista con DivideCadena y operara en un switch segun el operador extraido,
        /// finalmente modificara valor de entry con resultado de operacion
        /// </summary>
        public void ResultCommandExecute()
        {
            List<string> entryDividido = DivideCadena();//contiene numero, numero, operador

            double numeroDecimal1 = Convert.ToDouble(entryDividido[0]); //PROBLEMA CON PASAR DE DOUBLE A STRING RESTO DE FUNCIONAMIENTO CORRECTO
            double numeroDecimal2 = double.Parse(entryDividido[1]);
            string operador = entryDividido[2].ToString();
            double resultado = 0.0;

            switch (operador) 
            {
                case "+":
                    resultado = numeroDecimal1 + numeroDecimal2;
                    break;

                case "-" when numeroDecimal1 < numeroDecimal2:
                    resultado = numeroDecimal2 - numeroDecimal1;
                    break;

                case "-" when numeroDecimal1 >= numeroDecimal2:
                    resultado = numeroDecimal1 - numeroDecimal2;
                    break;

                case "X":
                    resultado = numeroDecimal1 * numeroDecimal2;
                    break;

                case "%" when numeroDecimal1 != 0.0:
                    resultado = numeroDecimal1 / numeroDecimal2;
                    break;

                case "%" when numeroDecimal1 == 0.0:
                    resultado = 0.0;
                    break;             
            }

            //compruebo si tras operacions resultado tiene un valor convertible a int
            if (!double.IsNaN(resultado) && !double.IsInfinity(resultado) && resultado >= int.MinValue && resultado <= int.MaxValue)
            {
                //en caso positivo lo paso a int y le doy a entry su valor
                int resultadoInt = (int)resultado;
                Entry = resultadoInt.ToString();
            }
            else
            {
                //de lo contrario le doy a entry su valor en double
                Entry = resultado.ToString();
            }
            NotifyPropertyChanged("Entry");
        }

        #endregion

        #region metodos y funciones

        /// <summary>
        /// funcion que refresca los check de los canExecutes de varios commands
        /// </summary>
        public void checkCanExecutes()
        {
            BackSpaceCommand.RaiseCanExecuteChanged();
            ResultCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// analiza tipo de digito y devuelve string acorde a tipo digito recibido
        /// </summary>
        /// <param name="digito"></param>
        /// <returns></returns>
        public string AnalizaDigito(string digito)
        {
            string resultado = "0";
            List<string> operadores = new List<string> { "+", "-", "X", "%" };
            List<string> numeros = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            foreach (string o in operadores)
            {
                if (digito.Equals(o))
                {
                    resultado = "operador";
                }
            }

            foreach (string n in numeros)
            {
                if (digito.Equals(n))
                {
                    resultado = "numero";
                }
            }

            if (digito==".")
            {
                resultado = "punto";
            }

            return resultado;

        }
        /// <summary>
        /// funcion que comprueba si entry contiene un caracter no permitido devolviendo estado permiso
        /// </summary>
        public bool PermisoAñadirOperador()
        {
            bool permiso = true;
            List<string> caracteresNoPermitidos = new List<string> { "+", "-", "X", "%" };

            if (Entry.Equals("0") || Entry.Equals("0."))
            {
                permiso = false;
            } 
            else
            {
                foreach (string c in caracteresNoPermitidos)
                {
                    if (Entry.Contains(c))
                    {
                        permiso = false;
                    }
                }
            }

            return permiso;
            #endregion
        }

        /// <summary>
        /// funcion que comprueba si ultimo caracter de entry contiene un caracter no permitido devolviendo estado permiso
        /// </summary>
        public bool PermisoAñadirPunto()
        {
            bool permiso = true;

            List<string> caracteresNoPermitidos = new List<string> { "+", "-", "X", "%", "." };//para invalidar punto si case 0
            List<string> operadorValidaPunto = new List<string> { "+", "-", "X", "%" };//para invalidar/validar punto en case 1
            int cuentaOperadores = 0;//para evitar break en case1

            string ultimoChar=Entry.Last().ToString();//devuelve ultimo char de entry en formato string
            int cuentaPuntos=Entry.Count(c => c == '.');//cuenta puntos actuales en entry
            

            switch (cuentaPuntos) { 
                case 2:
                    permiso = false; break ;

                case 1:
                    foreach (string c in operadorValidaPunto)
                    {
                        if (Entry.Contains(c))
                        {
                            cuentaOperadores += 1;
                        }
                    }
                    if (cuentaOperadores > 0 && !caracteresNoPermitidos.Contains(ultimoChar))
                    {
                        permiso = true;
                    } 
                    else
                    {
                        permiso = false;
                    }
                    break;

                case 0 when caracteresNoPermitidos.Contains(ultimoChar):
                    permiso = false; break;
            }

            return permiso;
        }

        /// <summary>
        /// funcion que creara lista con datos en entry y la devolvera
        /// </summary>
        /// <returns></returns>
        List<string> DivideCadena()
        {
            List<string> operadores = new List<string> { "+", "-", "X", "%" };
            string operador = "";

            //bucle for para saber que operador contiene entry
            foreach (string o in operadores)
            {
                if (Entry.Contains(o))
                {
                    operador = o;
                }
            }
            //divido entry en partes y las guardo en lista a partir de operador
            List<string> cadenaDividida = new List<string> (Entry.Split (operador));
            //lista anterior no tendra operador, solo "numeros" asi que añado operador al final
            cadenaDividida.Add(operador);

            return cadenaDividida;
        }

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

    }
}