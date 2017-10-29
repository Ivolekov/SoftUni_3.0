using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate_Sequence_with_Queue
{
    public class Program
    {
        public static void Main()
        {
            long startNumber = long.Parse(Console.ReadLine());
            int iterations = 50;
            Queue<long> queue = new Queue<long>();
            Queue<long> resultQueue = new Queue<long>();

            queue.Enqueue(startNumber);
            resultQueue.Enqueue(startNumber);
            int count = 1;

            while (count != iterations)
            {
                long x = queue.Dequeue();
                queue.Enqueue(x + 1);
                resultQueue.Enqueue(x + 1);
                count++;

                if (count == iterations)
                {
                    break;
                }

                queue.Enqueue(2 * x + 1);
                resultQueue.Enqueue(2 * x + 1);
                count++;

                if (count == iterations)
                {
                    break;
                }

                queue.Enqueue(x + 2);
                resultQueue.Enqueue(x + 2);
                count++;

                if (count == iterations)
                {
                    break;
                }
            }

            Console.Write(string.Join(" ", resultQueue));
        }
    }
}
