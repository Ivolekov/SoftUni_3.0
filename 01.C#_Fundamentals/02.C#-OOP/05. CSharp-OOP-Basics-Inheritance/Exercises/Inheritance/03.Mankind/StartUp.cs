using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentLine = Console.ReadLine().Split(' ');
                Student student = new Student(studentLine[0], studentLine[1], studentLine[2]);
                string[] workerLine = Console.ReadLine().Split(' ');
                Worker worker = new Worker(workerLine[0], workerLine[1], 
                    decimal.Parse(workerLine[2]), int.Parse(workerLine[3]));
                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
