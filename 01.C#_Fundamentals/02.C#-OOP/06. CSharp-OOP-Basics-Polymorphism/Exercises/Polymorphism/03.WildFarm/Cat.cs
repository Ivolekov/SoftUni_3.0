using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string animalName, double animalWeight, string livingRegion, string breed)
            : base(animalName, animalWeight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(Food food)
        {
            this.QuantityEatenFood += food.Quantity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Breed}, {base.AnimalWeight}, {base.LivingRegion}, {base.QuantityEatenFood}]");
            return base.ToString() + sb.ToString();
        }
    }
}
