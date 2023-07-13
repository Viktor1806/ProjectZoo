using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZoo
{
    internal class Animal
    {
        private string animalID;
        private string species;
        private string name;
        private int age;
        private string habitat;
        private bool availability;

        public Animal(string animalID, string species, string name, int age, string habitat, bool availability)
        {
            this.animalID = animalID;
            this.species = species;
            this.name = name;
            this.age = age;
            this.habitat = habitat;
            this.availability = availability;
        }

        public string AnimalID { get => animalID; set => animalID = value; }
        public string Species { get => species; set => species = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Habitat { get => habitat; set => habitat = value; }
        public bool Availability { get => availability; set => availability = value; }

    }
}

