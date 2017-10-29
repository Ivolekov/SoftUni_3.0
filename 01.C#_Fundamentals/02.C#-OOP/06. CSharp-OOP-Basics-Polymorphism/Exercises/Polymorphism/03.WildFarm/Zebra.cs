using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
    public class Zebra : Mammal
    {
        public Zebra(string animalName, double animalWeight, string livingRegion) 
            : base(animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Vegetable")
            {
                this.QuantityEatenFood += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} are not eating that type of food!");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.AnimalWeight}, {this.LivingRegion}, {this.QuantityEatenFood}]");
            return base.ToString() + sb.ToString();
        }
    }
}
