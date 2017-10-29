using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NumberInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            DecimalNumber decimalNumber = new DecimalNumber(n);
            Console.WriteLine(decimalNumber.ReversedNumber());
        }
    }

    public class DecimalNumber
    {
        decimal number;

        public DecimalNumber(decimal number)
        {
            this.number = number;
        }

        public decimal ReversedNumber()
        {
            string stringNumber = number.ToString();
            string resultNumber = string.Empty;
            for (int i = stringNumber.Length - 1; i >= 0; i--)
            {
                resultNumber += stringNumber[i];
            }
            return decimal.Parse(resultNumber);
        }
    }
}
