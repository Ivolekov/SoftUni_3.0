using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite.Interfaces
{
    interface ICommando
    {
        List<IMision> Misions { get; set; }
    }
}
