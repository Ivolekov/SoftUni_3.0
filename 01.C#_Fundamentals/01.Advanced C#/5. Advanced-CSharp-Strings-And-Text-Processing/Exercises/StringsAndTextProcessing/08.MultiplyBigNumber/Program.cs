using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart(new[] { '0' });
            int seconNumber = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            if (firstNumber == "0" || seconNumber == 0 || firstNumber == "")
            {
                Console.WriteLine(0);
                return;
            }


            int sum = 0;
            int numberInMind = 0;
            int reminder = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                sum = int.Parse(firstNumber[i].ToString()) * seconNumber + numberInMind;
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