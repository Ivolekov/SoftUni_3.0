using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
    public class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string animalName, double animalWeight, string livingRegion) 
            : base(animalName, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override void MakeSound()
        {
            throw new NotImplementedException();
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
