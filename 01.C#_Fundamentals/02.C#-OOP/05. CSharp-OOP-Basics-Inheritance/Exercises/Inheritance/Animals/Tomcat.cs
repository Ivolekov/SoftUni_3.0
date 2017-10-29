using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tomcat :Cat
    {
        public Tomcat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override void produceSound()
        {
            Console.WriteLine("Give me one million b***h");
        }
    }
}
