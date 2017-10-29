using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BirthdayCelebrations
{
    class Pet:IBirthdayble
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

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
