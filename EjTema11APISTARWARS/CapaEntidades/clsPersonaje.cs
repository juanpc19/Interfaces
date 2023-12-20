using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsPersonaje
    {
        #region atributos
        private string name;
        private string gender;
        #endregion

        #region contructores
        public clsPersonaje() { 
        }
        public clsPersonaje(string name, string gender)
        {
            this.name = name;
            this.gender = gender;
        }
        #endregion

        #region propiedades
        public string Name { get { return name; } }

        public string Gender { get {  return gender; } }
        #endregion



    }
}
