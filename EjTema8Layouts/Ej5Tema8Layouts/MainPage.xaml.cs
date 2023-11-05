
using LibreriaDeClases;
using System.Collections.ObjectModel;
using Ej5Tema8Layouts.Models;

namespace Ej5Tema8Layouts
{
    public partial class MainPage : ContentPage
    {

        //creo una colleccion observable de objetos Persona de nombre listadoPersonas y
        //le doy valor igual al devuelto por la funcion getListadoCompletoPersonas de la clase ListadoDePersonas que esta en Models
        ObservableCollection<Persona> listadoPersonas = ListadoDePersonas.getListadoCompletoPersonas();

        /// <summary>
        /// cargara listadoPersonas en el xaml al iniciarse
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            //doy a la lista de xaml de name ListadoPersonas el item listadoPersonas
            ListadoPersonas.ItemsSource = listadoPersonas;
             
        }




        // public ObservableCollection<Persona> listadoPersonas { get { return listadoPersonas; } }

        // ObservableCollection<Persona> listadoPersonas = new ObservableCollection<Persona>();



        //using System.Collections.ObjectModel;
        //namespace listview;

        //    public partial class MainPage : ContentPage
        //    {
        //        public class Fruit
        //        {
        //            public string FruitName { get; set; }
        //        }

        //        ObservableCollection<Fruit> fruits = new ObservableCollection<Fruit>();
        //        public ObservableCollection<Fruit> Fruits { get { return fruits; } }

        //        public MainPage()
        //        {
        //            InitializeComponent();

        //            fruits.Add(new Fruit() { FruitName = "Apple" });
        //            fruits.Add(new Fruit() { FruitName = "Orange" });
        //            fruits.Add(new Fruit() { FruitName = "Banana" });
        //            fruits.Add(new Fruit() { FruitName = "Grape" });
        //            fruits.Add(new Fruit() { FruitName = "Mango" });

        //            FruitListView.ItemsSource = fruits;

        //        }


        //    }


    }
}