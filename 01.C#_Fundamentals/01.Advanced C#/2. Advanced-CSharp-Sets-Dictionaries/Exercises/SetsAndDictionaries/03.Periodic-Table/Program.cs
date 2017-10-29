using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine().Trim().Split(' ');

                for (int j = 0; j < element.Length; j++)
                {
                    set.Add(element[j]);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
