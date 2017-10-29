using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KingGambit
{
    public class Footman : Unit
    {
        public Footman(string name) 
            : base(name)
        {
        }

        public override void Atack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
