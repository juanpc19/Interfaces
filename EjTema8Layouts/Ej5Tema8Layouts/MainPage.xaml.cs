
using LibreriaDeClases;
using System.Collections.ObjectModel;
using Ej5Tema8Layouts.Models;

namespace Ej5Tema8Layouts
{
    public partial class MainPage : ContentPage
    {
        // public ObservableCollection<Persona> listadoPersonas { get { return listadoPersonas; } }

        // ObservableCollection<Persona> listadoPersonas = new ObservableCollection<Persona>();


        /// <summary>
        /// 
        /// </summary>
        /// 
        ObservableCollection<Persona> listadoPersonas = ListadoDePersonas.getListadoCompletoPersonas();

        public MainPage()
        {
            InitializeComponent();

            ListadoPersonas.ItemsSource = listadoPersonas;
             
        }




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