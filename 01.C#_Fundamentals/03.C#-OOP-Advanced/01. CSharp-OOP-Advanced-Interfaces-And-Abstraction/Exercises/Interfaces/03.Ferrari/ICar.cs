using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    interface ICar
    {
        string Name { get; set; }

        void Break();

        void FullGas();
    }
}
