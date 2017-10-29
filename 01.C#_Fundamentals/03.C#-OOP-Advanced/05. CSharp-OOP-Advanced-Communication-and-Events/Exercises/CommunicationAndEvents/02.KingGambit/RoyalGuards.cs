using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KingGambit
{
    public class RoyalGuards : Unit
    {
        public RoyalGuards(string name) 
            : base(name)
        {
        }

        public override void Atack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
