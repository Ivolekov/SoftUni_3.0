using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ExcellentStudents
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
                var studentMarks = input.Split(' ').Skip(2).Select(int.Parse).ToArray();
                studentList.Add(new Student(studentFirstName, studentLastName, studentMarks));

                input = Console.ReadLine();
            }

            var result = studentList
                .Where(st => st.Marks.Contains(6))
                .Select(st => $"{st.FirstName} {st.LastName}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public class Student
        {
            public Student(string firsName, string lastName, int[] marks)
            {
                this.FirstName = firsName;
                this.LastName = lastName;
                this.Marks = marks;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int[] Marks { get; set; }
        }
    }
}
