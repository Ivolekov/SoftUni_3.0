using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
    public class Tiger :Felime
    {
        public Tiger(string animalName, double animalWeight, string livingRegion) 
            : base(animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.QuantityEatenFood += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
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
