using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsPersonaConListaDep
    {
        #region atributos
        private clsPersona persona;
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores

        public clsPersonaConListaDep()
        {
            this.persona = new clsPersona();
            this.listaDepartamentos = new List<clsDepartamento>();
        }
        public clsPersonaConListaDep(clsPersona persona, List<clsDepartamento> listaDepartamentos)
        {
            this.persona = persona;
            this.listaDepartamentos = listaDepartamentos;
        }
        #endregion

        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }

        #endregion

    }
}
