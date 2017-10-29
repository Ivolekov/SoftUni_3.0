using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite.Interfaces
{
    interface IEngineer
    {
        List<IRepair> Repairs { get; set; }
    }
}
