using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string str1 = elements[0];
            string str2 = elements[1];

            int sum = 0;
            string maxString = string.Empty;

            int maxLength = Math.Max(str1.Length, str2.Length);
            int minLength = Math.Min(str1.Length, str2.Length);

            if (str1.Length >= str2.Length)
            {
                maxString = str1;
            }
            else
            {
                maxString = str2;
            }
            for (int i = 0; i < maxLength; i++)
            {
                if (i < minLength)
                {
                    sum += str1[i] * str2[i];
                }
                else
                {
                    sum += maxString[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
