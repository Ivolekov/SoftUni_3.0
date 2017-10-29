using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KingGambit
{
    public abstract class Unit : IUnit
    {
        private string name;

        protected Unit(string name)
        {
            this.Name = name;
            this.IsAlive = true;
        }

        public string Name { get; }

        public bool IsAlive { get; }

        public abstract void Atack();
    }
}
