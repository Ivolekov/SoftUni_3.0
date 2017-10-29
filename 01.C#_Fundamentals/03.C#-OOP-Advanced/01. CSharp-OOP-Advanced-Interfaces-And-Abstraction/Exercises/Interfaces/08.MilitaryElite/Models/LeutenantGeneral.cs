using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private List<ISolder> privates;

        public LeutenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<ISolder>();
        }

        public List<ISolder> Privates { get; set; }

        public void AddPrivates(string id, List<ISolder> privates)
        {
            foreach (var @private in privates)
            {
                if (@private.Id.Equals(id))
                {
                    this.privates.Add(@private);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nPrivates:");
            foreach (var @private in Privates)
            {
                sb.AppendLine(@private.ToString());
            }
            return base.ToString() +sb;
        }
    }
}
