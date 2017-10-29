using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BirthdayCelebrations
{
    class Person : Citizen, IBirthdayble
    {
        private int age;
        private string birthdate;

        public Person(string nameOrModel, int age, string id, string birthdate)
            : base(nameOrModel, id)
        {
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public bool isBirthday(string year)
        {
            if (this.Birthdate.EndsWith(year))
            {
                return true;
            }

            return false;
        }
    }
}
