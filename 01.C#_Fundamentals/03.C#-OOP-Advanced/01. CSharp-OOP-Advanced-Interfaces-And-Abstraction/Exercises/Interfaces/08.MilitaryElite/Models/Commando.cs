using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMision> misions;

        public Commando(string id, string firstName, string lastName,
            double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Misions = new List<IMision>();
        }

        public List<IMision> Misions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Mission:");
            foreach (var mision in Misions)
            {
                sb.AppendLine(mision.ToString());
            }

            if (this.Misions.Count > 0)
            {
                return base.ToString() + sb;
            }

            return base.ToString();
        }
    }
}
