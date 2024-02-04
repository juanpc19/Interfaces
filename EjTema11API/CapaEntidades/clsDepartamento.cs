using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsDepartamento
    {
        #region atributos
        private int id;
        private string nombre;
        #endregion

        #region construtores
        public clsDepartamento()
        {
            id = 0;
            nombre = "";
        }

        public clsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;   
        }

        public clsDepartamento(clsDepartamento departamento)
        {
            this.id = departamento.Id;
            this.nombre = departamento.Nombre;
        }
        #endregion

        #region propiedades
        public int Id {  get { return id; } set { id = value; } }
        public string Nombre { get {  return nombre; } set { nombre = value; } }
        #endregion

    }
}
