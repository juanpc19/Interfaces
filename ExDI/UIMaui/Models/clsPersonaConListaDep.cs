using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMaui.CapaBL.Listados;
using UIMaui.ViewModels.Utilidades;

namespace UIMaui.Models
{
    public class clsPersonaConListaDep : INotifyPropertyChanged //, clsPersona
    {
        #region atributos
        private clsPersona persona;
        private clsDepartamento departamentoSeleccionado;
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        /// <summary>
        /// constructor con parametros que recibira la persona de una lista personas en VM, 
        /// el departamento seleccionado se le asignara a posteriori mediante interaccion con usuario y
        /// la lista de deps se le dara con el metodo recoger listado que hara llamada a api para recoger el listado
        /// </summary>
        /// <param name="persona"></param>
        public clsPersonaConListaDep(clsPersona persona, List<clsDepartamento> listadoDepartamentos)
        {
            this.persona = persona;
            this.departamentoSeleccionado = new clsDepartamento();
            this.listaDepartamentos = listadoDepartamentos;
        }
        #endregion

        #region propiedades
        

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set { departamentoSeleccionado = value; NotifyPropertyChanged(nameof(DepartamentoSeleccionado)); }
        }
        public clsPersona Persona
        {
            get { return persona; }
        }
        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }
        #endregion

        #region metodos
        public event PropertyChangedEventHandler PropertyChanged;//evento para notificar cambios en las propiedades

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
