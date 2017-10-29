using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, int> result = PrintMinNumber;
            Console.WriteLine(result(input));
        }

        public static int PrintMinNumber(List<int> n)
        {
            return n.Min();
        }
    }
}
