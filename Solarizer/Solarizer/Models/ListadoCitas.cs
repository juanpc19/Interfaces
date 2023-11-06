using Solarizer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarizer.Models
{
    internal static class ListadoCitas
    {

        public static ObservableCollection<Cita> getListadoCitas() {

            ObservableCollection<Cita> listadoCitas = new ObservableCollection<Cita> {
                new Cita("Antonio", "Calle florencia", 623123123, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Maite", "Calle Venecia", 656456456, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Federico", "Calle Urbion", 667567567, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Felipe", "Calle Verdu", 678678678, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Javier", "Calle Nervion", 689789789, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Francisco", "Calle Buhaira", 690890890, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Ana", "Calle Alhondiga", 698089098, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Maria", "Calle Juderia ", 621312321, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                new Cita("Dario", "Calle Cuba ", 624746391, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
            };

            return listadoCitas;
        }   
    }
}
