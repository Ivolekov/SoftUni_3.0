using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.FoodShortage.Interfaces;

namespace _07.FoodShortage.Models
{
    public abstract class Human : IBuyer
    {
        private string name;
        private int age;

        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
