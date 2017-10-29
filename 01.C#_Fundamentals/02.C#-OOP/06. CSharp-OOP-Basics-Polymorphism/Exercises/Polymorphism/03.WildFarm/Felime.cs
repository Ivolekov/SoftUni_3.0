using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
    public abstract class Felime : Mammal
    {
        public Felime(string animalName, double animalWeight, string livingRegion) 
            : base(animalName, animalWeight, livingRegion)
        {
        }
    }
}
