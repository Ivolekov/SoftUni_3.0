using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int quantityEatenFood;

        protected Animal(string animalName, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
            this.QuantityEatenFood = quantityEatenFood;
        }

        public string AnimalName { get; set; }

        public string AnimalType { get; set; }

        public double AnimalWeight { get; set; }

        public int QuantityEatenFood { get; set; }

        public abstract void MakeSound();

        public abstract void Eat(Food food);

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.Append($"{this.GetType().Name}[{this.AnimalName}, ");
            return sb.ToString();
        }
    }
}
