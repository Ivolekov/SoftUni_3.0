using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    public class Program
    {
        public static void Main()
        {
            int[] command = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = command[0];
            int s = command[1];
            int x = command[2];

            Stack<int> stack = new Stack<int>();

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            bool contains = stack.Contains(x);
            int[] arr = stack.ToArray();

            if (stack.Count == 0)
            {
                Console.WriteLine('0');
            }
            else if (contains)
            {
                Console.WriteLine("true");
            }
            else if (!contains)
            {
                Console.WriteLine(arr.Min());
            }
        }
    }
}
