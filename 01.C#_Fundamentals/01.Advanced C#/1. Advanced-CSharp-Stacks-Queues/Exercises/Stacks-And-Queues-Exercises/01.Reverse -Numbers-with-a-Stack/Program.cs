using System;
using System.Linq;
using System.Collections.Generic;
namespace _01.Reverse_Numbers_with_a_Stack
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> stackNumbers = new Stack<int>();

            foreach (var number in numbers)
            {
                stackNumbers.Push(number);
            }

            Console.Write(string.Join(" ", stackNumbers));

        }
    }
}
