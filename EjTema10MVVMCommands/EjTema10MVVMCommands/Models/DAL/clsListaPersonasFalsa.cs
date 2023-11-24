using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5tema9MVVM.Models.DAL
{
    internal static class clsListaPersonasFalsa
    {
        //añadir id //añadir id //añadir id
        public static List <clsPersona> getListaFalsa() {

            List<clsPersona> listadoFalsa = new List<clsPersona> {
                new clsPersona(0, "Antonio", "Perez de la huerta", "24/07/1995", "cosa", "Calle florencia", 623123123),
                new clsPersona(1, "Maite", "Diaz Gonzalez", "24/07/1995", "cosa", "Calle Venecia", 656456456),
                new clsPersona(2, "Federico", "Gil Sabina", "24/07/1995", "cosa", "Calle Urbion", 667567567),
                new clsPersona(3, "Felipe", "Gil Perez", "24/07/1995", "cosa", "Calle Verdu", 678678678),
                new clsPersona(4, "Javier", "Gil Alvarez",  "24/07/1995", "cosa","Calle Nervion", 689789789),
                new clsPersona(5, "Francisco", "Saavedra Puyol", "24/07/1995", "cosa", "Calle Buhaira", 690890890),
                new clsPersona(6, "Ana", "Valdivieso Perez", "24/07/1995", "cosa", "Calle Alhondiga", 698089098),
                new clsPersona(7, "Maria", "Rodriguez Perez", "24/07/1995", "cosa", "Calle Juderia ", 621312321),
                new clsPersona(8, "Dario", "Gil Diaz",  "24/07/1995", "cosa", "Calle Cuba ", 624746391)
            };


            return listadoFalsa;
        }
    }
}
