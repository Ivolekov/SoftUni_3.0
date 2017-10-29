using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterStudentsByEmailDomain
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
                string studentEmail = token[2];
                studentList.Add(new Student(studentFirstName, studentLastName, studentEmail));

                input = Console.ReadLine();
            }

            var result = studentList.Where(st => st.Email.Contains("@gmail.com"))
                .Select(st => $"{st.FirstName} {st.LastName}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public class Student
        {
            public Student(string firsName, string lastName, string email)
            {
                this.FirstName = firsName;
                this.LastName = lastName;
                this.Email = email;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}
