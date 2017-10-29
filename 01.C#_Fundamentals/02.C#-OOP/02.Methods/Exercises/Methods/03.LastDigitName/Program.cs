using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LastDigitName
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Number num = new Number(number);
            Console.WriteLine(num.EnglishNameOfTheLastDigit());
        }
    }

    public class Number
    {
        int number;

        public Number(int number)
        {
            this.number = number;
        }

        public string EnglishNameOfTheLastDigit()
        {
            string digitName = string.Empty;
            switch (number % 10)
            {
                case 0:
                    digitName = "zero";
                    break;
                case 1:
                    digitName = "one";
                    break;
                case 2:
                    digitName = "two";
                    break;
                case 3:
                    digitName = "three";
                    break;
                case 4:
                    digitName = "four";
                    break;
                case 5:
                    digitName = "five";
                    break;
                case 6:
                    digitName = "six";
                    break;
                case 7:
                    digitName = "seven";
                    break;
                case 8:
                    digitName = "eight";
                    break;
                case 9:
                    digitName = "nine";
                    break;

            }
            return digitName;
        }
    }
}
