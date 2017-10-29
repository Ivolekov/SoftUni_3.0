using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string inputName = input[i];

                Action<string> name = Print;
                name(inputName);
            }
        }

        public static void Print(string name)
        {
            Console.WriteLine($"Sir {name}");
        }
    }
}
