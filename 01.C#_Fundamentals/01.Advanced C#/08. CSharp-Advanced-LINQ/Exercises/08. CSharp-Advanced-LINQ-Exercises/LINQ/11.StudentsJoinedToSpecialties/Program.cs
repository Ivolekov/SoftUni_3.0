using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.StudentsJoinedToSpecialties
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<StudentSpecialty> studentSoeciality = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();

            while (input[0] != "Students:")
            {
                studentSoeciality.Add(new StudentSpecialty($"{input[0]} {input[1]}", input[2]));
                input = Console.ReadLine().Split(' ');
                if (input[0] == "Students:")
                {
                    input = Console.ReadLine().Split(' ');
                    while (input[0] != "END")
                    {
                        if (input[0] == "END")
                        {
                            break;
                        }
                        students.Add(new Student($"{input[1]} {input[2]}", input[0]));
                        input = Console.ReadLine().Split(' ');
                    }
                    if (input[0] == "END")
                    {
                        break;
                    }
                }
            }

            var joint = from sp in studentSoeciality
                        join st in students
                        on sp.FacultyNumber equals st.FacultyNumber
                        select new { st.StudentName, st.FacultyNumber, sp.SpecialtyName };
            joint.OrderBy(st => st.StudentName).ToList()
            .ForEach(s => Console.WriteLine($"{s.StudentName} {s.FacultyNumber} {s.SpecialtyName}"));
        }
    }

    public class StudentSpecialty
    {
        public StudentSpecialty(string specialtyName, string facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber { get; set; }
        public string SpecialtyName { get; set; }
    }

    public class Student
    {
        public Student(string studentName, string facultyNumber)
        {
            this.StudentName = studentName;
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber { get; set; }
        public string StudentName { get; set; }
    }
}
