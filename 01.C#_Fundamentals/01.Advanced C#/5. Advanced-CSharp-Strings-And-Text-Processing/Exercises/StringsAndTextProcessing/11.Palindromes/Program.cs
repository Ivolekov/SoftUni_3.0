using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', ',', '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> result = new SortedSet<string>();
            for (int i = 0; i < input.Length; i++)
            {
                char[] forReversed = input[i].ToCharArray();
                Array.Reverse(forReversed);
                string reversed = string.Empty;
                for (int j = 0; j < forReversed.Length; j++)
                {
                    reversed += forReversed[j];
                }
                if (input[i] == reversed.ToString())
                {
                    result.Add(input[i]);
                }
            }
            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }
    }
}
