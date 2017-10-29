using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentsEnrolledIn2014Or2015
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            while (input[0] != "END")
            {
                if (input[0]=="END")
                {
                    break;
                }

                int facNum = int.Parse(input[0]);

                if (facNum % 10 == 5 || facNum % 10 == 4)
                {
                    input.Skip(1).ToList().ForEach(g => Console.Write(g + " "));
                    Console.WriteLine();
                }

                input = Console.ReadLine().Split(' ').ToList();
            }
        }
    }

}
