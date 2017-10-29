using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FilterStudentsByPhone
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
                string studentPhone = token[2];
                studentList.Add(new Student(studentFirstName, studentLastName, studentPhone));

                input = Console.ReadLine();
            }

            var result = studentList.Where(st => st.Phone.IndexOf("02") == 0 || st.Phone.IndexOf("+3592") == 0)
                .Select(st => $"{st.FirstName} {st.LastName}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public class Student
        {
            public Student(string firsName, string lastName, string phone)
            {
                this.FirstName = firsName;
                this.LastName = lastName;
                this.Phone = phone;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
        }
    }
}
