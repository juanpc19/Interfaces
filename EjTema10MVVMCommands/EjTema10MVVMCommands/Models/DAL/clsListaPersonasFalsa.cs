using EjTema10MVVMCommands.Models.Entidades;

namespace EjTema10MVVMCommands.Models.DAL
{
    internal static class clsListaPersonasFalsa
    {
       
        public static List <clsPersona> getListaFalsa() {

            List<clsPersona> listadoFalsa = new List<clsPersona> {
                new clsPersona(1, "John", "Doe", "656565643", "123 Main St", "https://thispersondoesnotexist.com/", new DateTime(1990, 5, 15), 1),
                new clsPersona(2, "Jane", "Smith", "656565643", "456 Elm St", "https://thispersondoesnotexist.com/", new DateTime(1988, 9, 20), 2),
                new clsPersona(3, "Alice", "Johnson", "656565643", "789 Oak St", "https://thispersondoesnotexist.com/", new DateTime(1985, 12, 10), 3),
                new clsPersona(4, "Bob", "Williams", "656565643", "567 Pine St", "https://thispersondoesnotexist.com/", new DateTime(1995, 3, 25), 4),
                new clsPersona(5, "Ella", "Brown", "656565643", "901 Maple St", "https://thispersondoesnotexist.com/", new DateTime(1980, 8, 5), 5),
                new clsPersona(6, "Mike", "Garcia", "656565643", "345 Cedar St", "https://thispersondoesnotexist.com/", new DateTime(1975, 11, 18), 6),
                new clsPersona(7, "Sarah", "Martinez", "656565643", "678 Walnut St", "https://thispersondoesnotexist.com/", new DateTime(1992, 6, 30), 7),
                new clsPersona(8, "David", "Lopez", "656565643", "234 Birch St", "https://thispersondoesnotexist.com/", new DateTime(1987, 2, 14), 1),
                new clsPersona(9, "Emily", "Lee", "656565643", "789 Spruce St", "https://thispersondoesnotexist.com/", new DateTime(1998, 7, 8), 1),
                new clsPersona(10, "Daniel", "Nguyen", "656565643", "321 Fir St", "https://thispersondoesnotexist.com/", new DateTime(1983, 9, 22), 1)
        };


            return listadoFalsa;
        }
    }
}
