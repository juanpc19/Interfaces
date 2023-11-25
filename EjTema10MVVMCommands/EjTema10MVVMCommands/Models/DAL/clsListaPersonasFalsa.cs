using EjTema10MVVMCommands.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema10MVVMCommands.Models.DAL
{
    internal static class clsListaPersonasFalsa
    {
        //añadir id //añadir id //añadir id
        public static List <clsPersona2> getListaFalsa() {

            List<clsPersona2> listadoFalsa = new List<clsPersona2> {
                new clsPersona2(0, "Antonio", "Perez de la huerta", "24/07/1995", "cosa", "Calle florencia", 623123123),
                new clsPersona2(1, "Maite", "Diaz Gonzalez", "24/07/1995", "cosa", "Calle Venecia", 656456456),
                new clsPersona2(2, "Federico", "Gil Sabina", "24/07/1995", "cosa", "Calle Urbion", 667567567),
                new clsPersona2(3, "Felipe", "Gil Perez", "24/07/1995", "cosa", "Calle Verdu", 678678678),
                new clsPersona2(4, "Javier", "Gil Alvarez",  "24/07/1995", "cosa","Calle Nervion", 689789789),
                new clsPersona2(5, "Francisco", "Saavedra Puyol", "24/07/1995", "cosa", "Calle Buhaira", 690890890),
                new clsPersona2(6, "Ana", "Valdivieso Perez", "24/07/1995", "cosa", "Calle Alhondiga", 698089098),
                new clsPersona2(7, "Maria", "Rodriguez Perez", "24/07/1995", "cosa", "Calle Juderia ", 621312321),
                new clsPersona2(8, "Dario", "Gil Diaz",  "24/07/1995", "cosa", "Calle Cuba ", 624746391)
            };


            return listadoFalsa;
        }
    }
}
