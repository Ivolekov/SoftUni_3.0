using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                Student student = new Student(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(Student.StudentCounter);
        }
    }

    public class Student
    {
        static int count = 0;

        public static int StudentCounter
        {
            get { return Student.count; }
        }
        public Student(string name)
        {
            Student.count++;
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
