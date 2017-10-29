using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KingGambit
{
    public class King : Unit
    {
        public King(string name) 
            : base(name)
        {
        }

        public override void Atack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
        }
    }
}
