using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Kitten :Cat
    {
        public Kitten(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override void produceSound()
        {
            Console.WriteLine("Miau");
        }
    }
}
