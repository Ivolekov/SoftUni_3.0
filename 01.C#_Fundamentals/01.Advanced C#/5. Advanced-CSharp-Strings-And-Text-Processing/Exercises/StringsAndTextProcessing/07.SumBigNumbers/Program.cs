using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart(new[] { '0' });
            string seconNumber = Console.ReadLine().TrimStart(new[] { '0' });

            StringBuilder result = new StringBuilder();

            if (firstNumber.Length > seconNumber.Length)
            {
                seconNumber = seconNumber.PadLeft(firstNumber.Length, '0');
            }
            else
            {
                firstNumber = firstNumber.PadLeft(seconNumber.Length, '0');
            }

            int sum = 0;
            int numberInMind = 0;
            int reminder = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                sum = int.Parse(firstNumber[i].ToString()) + int.Parse(seconNumber[i].ToString()) + numberInMind;
                numberInMind = sum / 10;
                reminder = sum % 10;
                result.Append(reminder);
                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            char[] resultChar = result.ToString().ToCharArray();
            Array.Reverse(resultChar);
            Console.WriteLine(resultChar);
        }
    }
}
