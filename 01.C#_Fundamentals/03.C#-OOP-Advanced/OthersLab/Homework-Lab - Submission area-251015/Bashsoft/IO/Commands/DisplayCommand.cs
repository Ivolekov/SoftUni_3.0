namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using Attributes;
    using Contracts;
    using Exceptions;
    using Models;

    [Alias("display")]
    public class DisplayCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = this.Data[1];
            string sortType = this.Data[2];
            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<Student> studentComparer = this.CreateComparer<Student>(sortType);
                ISimpleOrderedBag<Student> list = this.repository.GetAllStudentsSorted(studentComparer);
                OutputWriter.WriteMessageLine(list.JoinWith(Environment.NewLine), ConsoleColor.Blue);
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<Course> courseComparer = this.CreateComparer<Course>(sortType);
                ISimpleOrderedBag<Course> list = this.repository.GetAllCoursesSorted(courseComparer);
                OutputWriter.WriteMessageLine(list.JoinWith(Environment.NewLine), ConsoleColor.Blue);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private Comparer<T> CreateComparer<T>(string sortType) where T : IComparable<T>
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<T>.Create((t1, t2) => t1.CompareTo(t2));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<T>.Create((t1, t2) => t2.CompareTo(t1));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
