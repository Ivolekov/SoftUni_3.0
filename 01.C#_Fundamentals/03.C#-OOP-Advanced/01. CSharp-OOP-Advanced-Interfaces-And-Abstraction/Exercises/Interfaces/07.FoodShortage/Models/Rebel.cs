using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FoodShortage.Models
{
    class Rebel : Human
    {
        private string group;

        public Rebel(string name, int age, string group) 
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; set; }

        public override void BuyFood()
        {
            base.Food += 5;
        }
    }
}
