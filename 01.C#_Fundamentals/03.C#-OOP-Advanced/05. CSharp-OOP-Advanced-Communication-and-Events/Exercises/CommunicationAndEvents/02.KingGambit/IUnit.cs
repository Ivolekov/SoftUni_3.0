using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KingGambit
{
    public interface IUnit
    {
        string Name { get; }

        bool IsAlive { get; }

        void Atack();
    }
}
