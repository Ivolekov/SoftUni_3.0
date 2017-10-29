using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    class Repair :IRepair
    {
        private string partName;
        private int workHours;

        public Repair(string partName, int workHours)
        {
            this.PartName = partName;
            this.WorkHours = workHours;
        }

        public string PartName { get; set; }
        public int WorkHours { get; set; }
    }
}
