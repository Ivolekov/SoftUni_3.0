using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02.UniqueStudentNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            while (input != "End")
            {
                string name = input;

                StudentdGroup students = new StudentdGroup(new Student(input));
                //Student student = new Student(name);
                //students.students.Add(student);
                input = Console.ReadLine();
            }
            Console.WriteLine(StudentdGroup.StudentCounter);
        }
    }

    public class Student
    {
        public string name;

        public Student(string name)
        {
            this.name = name;
        }
    }

    public class StudentdGroup
    {
        public HashSet<Student> students;
        public static int count;
        public Student student;
        public static int StudentCounter
        {
            get { return StudentdGroup.count; }
        }
        public StudentdGroup(Student student)
        {
            this.students = new HashSet<Student>();
            if (students.Contains(student))
            {
                count++;
            }
        }
    }
}
