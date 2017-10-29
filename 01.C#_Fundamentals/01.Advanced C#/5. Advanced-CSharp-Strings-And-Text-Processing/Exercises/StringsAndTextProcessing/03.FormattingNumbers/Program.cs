using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FormattingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[]{ ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(input[0]);
            string hex = a.ToString("X");
            string binary = Convert.ToString(a,2);
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);

            Console.WriteLine("|{0:X}|{1}|{2}|{3}|", 
                hex.PadRight(10,' '), binary.PadLeft(10,'0').Substring(0,10), b.ToString("0.00").PadLeft(10,' '), c.ToString("0.000").PadRight(10,' '));
        }
    }
}
