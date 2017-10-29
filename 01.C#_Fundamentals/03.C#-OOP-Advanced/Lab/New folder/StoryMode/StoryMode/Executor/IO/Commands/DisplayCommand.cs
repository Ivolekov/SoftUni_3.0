namespace Executor.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using Executor.Attributes;
    using Executor.Contracts;
    using Executor.Contracts.DataStructures;
    using Executor.Contracts.Repository;
    using Executor.Exceptions;
    using Executor.Models.Contracts;
    using Executor.Repository.Contacts;

    [Alias("display")]
    public class DisplayCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input,string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            string[] data = this.Data;

            if (data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = data[1];
            string sortType = data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<Student> studentComparator = this.CreateStudentComparator(sortType);
                ISimpleOrderedBag<Student> list = this.repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<Course> courseComparator = this.CreateCourseComparator(sortType);
                ISimpleOrderedBag<Course> list = this.repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
        }

        private IComparer<Student> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Student>.Create((student, student1) => student.CompareTo(student1));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Student>.Create((student, student1) => student1.CompareTo(student));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<Course> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Course>.Create((course, course1) => course.CompareTo(course1));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Course>.Create((course, course1) => course1.CompareTo(course));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}