using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FoodShortage.Models
{
    class Citizen  :Human
    {
        private string id;
        private string brthdate;

        public Citizen(string name, int age, string id, string birthdate)
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public override void BuyFood()
        {
            base.Food += 10;
        }
    }
}
