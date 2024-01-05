using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsPersonaje
    {
        #region atributos
        private string name;
        private string height;
        private string mass;
        private string hair_color;
        private string skin_color;
        private string eye_color;
        private string birth_year;
        private string gender;
        private string homeworld;
        private List<string> films;
        private List<string> species;
        private List<string> vehicles;
        private List<string> starships;
        private string created;
        private string edited;
        private string url;
        #endregion

        #region contructores
        public clsPersonaje() { 
        }

        public clsPersonaje(string name, string height, string mass, string hair_color, string skin_color, string eye_color, string birth_year, string gender, string homeworld, List<string> films, List<string> species, List<string> vehicles, List<string> starships, string created, string edited, string url)
        {
            this.name = name;
            this.height = height;
            this.mass = mass;
            this.hair_color = hair_color;
            this.skin_color = skin_color;
            this.eye_color = eye_color;
            this.birth_year = birth_year;
            this.gender = gender;
            this.homeworld = homeworld;
            this.films = films;
            this.species = species;
            this.vehicles = vehicles;
            this.starships = starships;
            this.created = created;
            this.edited = edited;
            this.url = url;
        }
        #endregion


        #region propiedades
        //tendran sets publicos porque son necesarios para deserializar
        public string Name { get { return name; } set { name = value; } }
        public string Height { get { return height; } set { height = value; } }
        public string Mass { get { return mass; } set { mass = value; } }
        public string Hair_color { get { return hair_color; } set { hair_color = value; } }
        public string Skin_color { get { return skin_color; } set { skin_color = value; } }
        public string Eye_color { get { return eye_color; } set { eye_color = value; } }
        public string Birth_year { get { return birth_year; } set { birth_year = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Homeworld { get { return homeworld; } set { homeworld = value; } }
        public List<string> Films { get { return films; } set { films = value; } }
        public List<string> Species { get { return species; } set { species = value; } }
        public List<string> Vehicles { get { return vehicles; } set { vehicles = value; } }
        public List<string> Starships { get { return starships; } set { starships = value; } }
        public string Created { get { return created; } set { created = value; } }
        public string Edited { get { return edited; } set { edited = value; } }
        public string Url { get { return url; } set { url = value; } }
        #endregion

    }
}
