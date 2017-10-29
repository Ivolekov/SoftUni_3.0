using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sets_of_Elements
{
    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();

            int n = input[0];
            int m = input[1];
            HashSet<int> set = new HashSet<int>();
            HashSet<int> resultSet = new HashSet<int>();

            for (int i = 0; i < n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                bool currentNumber = set.Contains(number);
                set.Add(number);

                if (currentNumber)
                {
                    resultSet.Add(number);
                }
            }

            Console.Write(string.Join(" ", resultSet));
        }
    }
}
