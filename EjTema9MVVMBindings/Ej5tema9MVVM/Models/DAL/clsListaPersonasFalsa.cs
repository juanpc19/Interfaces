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

        public static ObservableCollection <clsPersona> getListaFalsa() {

            ObservableCollection <clsPersona> listadoFalsa = new ObservableCollection<clsPersona> {
                new clsPersona("Antonio", "Perez de la huerta", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle florencia", 623123123),
                new clsPersona("Maite", "Diaz Gonzalez", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Venecia", 656456456),
                new clsPersona("Federico", "Gil Sabina", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Urbion", 667567567),
                new clsPersona("Felipe", "Gil Perez", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Verdu", 678678678),
                new clsPersona("Javier", "Gil Alvarez",  "24/07/1995", "https://thispersondoesnotexist.com/","Calle Nervion", 689789789),
                new clsPersona("Francisco", "Saavedra Puyol", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Buhaira", 690890890),
                new clsPersona("Ana", "Valdivieso Perez", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Alhondiga", 698089098),
                new clsPersona("Maria", "Rodriguez Perez", "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Juderia ", 621312321),
                new clsPersona("Dario", "Gil Diaz",  "24/07/1995", "https://thispersondoesnotexist.com/", "Calle Cuba ", 624746391)
            };


            return listadoFalsa;
        }
    }
}
