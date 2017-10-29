using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < input.Length; i++)
            {
                string inputName = input[i];

                Action<string> name = Print;
                name(inputName);
            }
        }

        public static void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
