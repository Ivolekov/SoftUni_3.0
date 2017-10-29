using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentsByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentList = new List<Student>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "END")
                {
                    break;
                }

                string[] token = input.Split(' ');
                string studentFirstName = token[0];
                string studentLastName = token[1];
                int studentAge = int.Parse(token[2]);
                studentList.Add(new Student(studentFirstName, studentLastName, studentAge));

                input = Console.ReadLine();
            }

            var result = studentList.Where(st => st.Age <= 24 && st.Age >= 18)
                .Select(st => $"{st.FirstName} {st.LastName} {st.Age}");

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }

    public class Student
    {
        public Student(string firsName, string lastName, int age)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
