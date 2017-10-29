using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortStudents
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
                studentList.Add(new Student(studentFirstName, studentLastName));

                input = Console.ReadLine();
            }

            var result = studentList.OrderBy(st => st.LastName).ThenByDescending(st=>st.FirstName)
                .Select(st=>$"{st.FirstName} {st.LastName}");

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }

    public class Student
    {
        public Student(string firsName, string lastName)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
