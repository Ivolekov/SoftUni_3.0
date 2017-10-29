using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.MethodSaysHello
{
    static class Program
    {
        static void Main()
        {
            Person p = new Person("Pesho");
            Console.WriteLine(p.SayHello());
        }
    }

    
}
