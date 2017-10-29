using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Google
{
    class Company
    {
        public string name;
        public string deparment;
        public decimal salary;

        public Company(string name, string deparment, decimal salary)
        {
            this.name = name;
            this.deparment = deparment;
            this.salary = salary;
        }
    }
}
