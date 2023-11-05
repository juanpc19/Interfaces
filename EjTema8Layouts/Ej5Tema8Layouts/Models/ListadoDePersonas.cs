using LibreriaDeClases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ej5Tema8Layouts.Models

{
    /// <summary>
    /// clase estatica que contiene funcion que devuelve un ObservableCollection
    /// </summary>
    public static class ListadoDePersonas
    {
        /// <summary>
        /// funcion que devuelve collecion observable de objetos Personas creados a mano
        /// Pre: ninguna
        /// Post: devolvera un ObservableCollection
        /// </summary>
        /// <returns>listadoPersonas</returns>
        public static ObservableCollection<Persona> getListadoCompletoPersonas()
        {
            ObservableCollection<Persona> listadoPersonas = new ObservableCollection<Persona>() {

            new Persona("Juan", "Gallego Lopez"),
            new Persona("Jaime", "Garcia Lorca"),
            new Persona("Antonio", "Perez Garcia"),
            new Persona("Pepe", "Garcia Gallego"),
            new Persona("Javier", "Lorca Diaz"),
            new Persona("Eustaquio", "Gallego Lopez"),
            new Persona("Jesus", "Garcia Lorca"),
            new Persona("Jose", "Perez Garcia"),
            new Persona("Ignacio", "Garcia Gallego"),
            new Persona("Luis", "Lorca Diaz"),

        };

            return listadoPersonas;

        }
    }


}
