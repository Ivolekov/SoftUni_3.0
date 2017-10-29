using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Exceptions;
using Executor.Contracts;

namespace Executor.Models
{
    public class SoftUniCourse : Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, Student> studentsByName;

        public SoftUniCourse(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get
            {
                return this.studentsByName;
            }
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.GetName()))
            {
                throw new DuplicateEntryInStructureException(student.GetName(), this.Name);
            }

            this.studentsByName.Add(student.GetName(), student);
        }

        public string GetName()
        {
            return this.name;
        }

        public Dictionary<string, Student> GetStudentByName()
        {
            return this.studentsByName;
        }

        public int CompareTo(Course other) => string.Compare(this.Name, other.GetName(), StringComparison.Ordinal);
        public override string ToString() => this.Name;
    }
}
