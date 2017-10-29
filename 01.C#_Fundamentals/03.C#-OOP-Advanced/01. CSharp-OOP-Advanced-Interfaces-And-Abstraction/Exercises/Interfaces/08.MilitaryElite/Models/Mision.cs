using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    class Mision : IMision
    {
        private string codeName;
        private string state;

        public Mision(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Code Name: {this.CodeName} State: {this.State}");
            return sb.ToString();
        }
    }
}
