using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.WeakStudents
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
                var studentMarks = input.Split(' ').Skip(2).Select(int.Parse).ToList();
                var sortedMarks = studentMarks.OrderBy(m => m).ToList();

                if (sortedMarks[1] <= 3)
                {
                    studentList.Add(new Student(studentFirstName, studentLastName, studentMarks));

                }

                input = Console.ReadLine();
            }

            foreach (var item in studentList)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }

    public class Student
    {
        public Student(string firsName, string lastName, List<int> marks)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
            this.Marks = marks;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Marks { get; set; }
    }
}
