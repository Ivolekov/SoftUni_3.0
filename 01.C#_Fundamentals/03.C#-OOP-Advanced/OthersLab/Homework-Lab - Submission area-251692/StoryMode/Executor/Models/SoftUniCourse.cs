using System;
using System.Collections.Generic;
using Executor.Exceptions;
using Executor.Contracts;

namespace Executor.Models
{
    public class SoftUniCourse : Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, SoftUniStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, SoftUniStudent>();
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

        public IReadOnlyDictionary<string, SoftUniStudent> StudentByName
        {
            get { return this.studentsByName; }
        }

        IReadOnlyDictionary<string, Student> Course.StudentByName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void EnrollStudent(SoftUniStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);
        }

        public int CompareTo(Course other) => String.Compare(this.Name, other.Name, StringComparison.Ordinal);

        public override string ToString() => this.Name;

        public void EnrollStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
