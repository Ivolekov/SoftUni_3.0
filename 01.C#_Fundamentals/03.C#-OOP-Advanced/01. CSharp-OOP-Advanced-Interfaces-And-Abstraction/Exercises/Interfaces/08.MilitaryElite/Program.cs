using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MilitaryElite.Models;

namespace _08.MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            Private p = new Private("1", "Pesho", "Peshev", 22.22);
            Private p1 = new Private("222", "Toncho", "Tonchev", 80.08);

            LeutenantGeneral l = new LeutenantGeneral("3", "Joro", "Jorev", 100);
            l.Privates.Add(p);
            l.Privates.Add(p1);

            Commando c = new Commando("13", "Stamat", "Stamov", 13.1, "Airforces");
            Console.WriteLine(p);
            Console.Write(l);
            Console.WriteLine(c);
            c.Misions.Add(new Mision("1", "2"));
        }
    }
}
