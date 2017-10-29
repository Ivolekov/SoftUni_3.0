using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        stack.Push(command[1]);
                        if (max < command[1])
                        {
                            max = command[1];
                        }
                        break;
                    case 2:
                        int element = stack.Pop();

                        if (element == max && stack.Count > 0)
                        {
                            max = stack.Max();
                        }
                        else if (element == max && stack.Count == 0)
                        {
                            max = 0;
                        }
                        break;
                    case 3:
                        Console.WriteLine(max);
                        break;
                }
            }
        }
    }
}
