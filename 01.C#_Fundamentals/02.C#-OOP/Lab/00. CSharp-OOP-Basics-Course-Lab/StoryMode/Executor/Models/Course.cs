using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Exceptions;

namespace Executor.Models
{
    class Course
    {
        private string name;
        private Dictionary<string, Student> studentsByName;

        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public Dictionary<string, Student> StudentsByName
        {
            get { return studentsByName; }
        }

        public void EnrollStudent(Student student)
        {
            if (!studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
                //OutputWriter.DisplayException(string.Format(
                //    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                //    student.UserName, this.name));
                //return;
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}
