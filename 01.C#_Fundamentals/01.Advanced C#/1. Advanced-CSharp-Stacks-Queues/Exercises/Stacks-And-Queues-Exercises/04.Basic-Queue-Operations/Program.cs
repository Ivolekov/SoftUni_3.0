using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    public class Program
    {
        public static void Main()
        {
            int[] command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = command[0];
            int s = command[1];
            int x = command[2];

            Queue<int> queue = new Queue<int>();

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                queue.Enqueue(number);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            bool contain = queue.Contains(x);

            if (queue.Count == 0)
            {
                Console.WriteLine('0');
            }
            else if (contain)
            {
                Console.WriteLine("true");
            }
            else if (!contain)
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
