using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BorderControl
{
    class Person : Citizen
    {
        private int age;

        public Person(string nameOrModel, int age, string id) : base(nameOrModel, id)
        {
            this.Age = age;
        }

        public int Age{ get; set; }
    }
}
