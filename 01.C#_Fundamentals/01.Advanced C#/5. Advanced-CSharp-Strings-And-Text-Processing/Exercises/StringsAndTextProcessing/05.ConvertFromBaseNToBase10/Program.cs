using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConvertFromBase10ToBaseN
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            BigInteger toBase = BigInteger.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);
            string result = string.Empty;

            while (number > 0)
            {
                result += number % toBase;
                number /= toBase;
            }

            char[] reversed = result.ToCharArray();
            Array.Reverse(reversed);
            Console.WriteLine(reversed);
        }
    }
}
