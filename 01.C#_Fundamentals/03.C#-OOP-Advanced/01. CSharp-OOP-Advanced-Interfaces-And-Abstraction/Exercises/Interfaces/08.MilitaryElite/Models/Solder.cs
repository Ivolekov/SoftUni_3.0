using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    public abstract class Solder : ISolder
    {
        private string id;
        private string firstName;
        private string lastName;

        protected Solder(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} ");

            return sb.ToString();
        }
    }
}
