
using LibreriaDeClases;
using System.Collections.ObjectModel;

namespace Ej5Tema8Layouts
{
    public partial class MainPage : ContentPage
    {


        // public ObservableCollection<Persona> listadoPersonas { get { return listadoPersonas; } }

        // ObservableCollection<Persona> listadoPersonas = new ObservableCollection<Persona>();

     

        /// <summary>
        /// crear objetos en main page start
        /// </summary>
        /// 

        ObservableCollection<Persona> listadoPersonas = new ObservableCollection<Persona>();

        public MainPage()
        {
            InitializeComponent();
           

            {
                listadoPersonas.Add(new Persona("Juan", "Gallego Lopez"));
                listadoPersonas.Add(new Persona("Jaime", "Garcia Lorca"));
                listadoPersonas.Add(new Persona("Antonio", "Perez Garcia"));
                listadoPersonas.Add(new Persona("Pepe", "Garcia Gallego"));
                listadoPersonas.Add(new Persona("Felipe", "Lorca Diaz"));

                ListadoDePersonas.ItemsSource = listadoPersonas;
            };
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