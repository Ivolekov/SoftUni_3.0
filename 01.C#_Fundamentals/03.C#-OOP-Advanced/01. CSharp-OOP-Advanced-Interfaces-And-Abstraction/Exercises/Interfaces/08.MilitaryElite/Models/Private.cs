using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    public class Private : Solder, IPrivate
    {
        private double salary;

        public Private(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Salary: {this.Salary:F2}");
            return base.ToString() + sb;
        }
    }
}
