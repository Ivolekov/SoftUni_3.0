using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StudentsByGroup
{
    public class Student
    {
        public Student(string firsName, string lastName, int group)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
            this.Group = group;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }
    }

    public class Program
    {
        public static void Main()
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
                int studentGroup = int.Parse(token[2]);
                studentList.Add(new Student(studentFirstName, studentLastName, studentGroup));

                input = Console.ReadLine();
            }

            var result = studentList.Where(st => st.Group == 2)
                .OrderBy(st => st.FirstName)
                .Select(st => $"{st.FirstName} {st.LastName}")
                .ToList();
            foreach (var student in result)
            {
                Console.WriteLine();
            }
        }
    }
}
