using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite.Interfaces
{
    interface ILeutenantGeneral
    {
        List<ISolder> Privates { get; set; }

        void AddPrivates(string id, List<ISolder> privates);
    }
}
