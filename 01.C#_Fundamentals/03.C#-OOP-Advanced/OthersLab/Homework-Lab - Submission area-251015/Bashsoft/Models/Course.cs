namespace Lab.AdvancedCSharp.Bashsoft.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;

    public class Course : ICourse
    {
        #region Constants

        public const int NumberOfTasksOnExam = 5;

        public const int MaxScoreOnExamTask = 100;

        #endregion

        #region Private Fields

        private readonly Dictionary<string, IStudent> studentsByName;

        private string name;

        #endregion

        #region Constructors

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        #endregion

        #region Properties
        
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

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get
            {
                return this.studentsByName;
            }
        }

        #endregion

        #region Public Methods

        public int CompareTo(Course other)
        {
            return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.Name))
            {
                throw new DuplicateEntryInStructureException(
                   student.Name,
                   this.name);
            }

            this.studentsByName.Add(student.Name, student);
        }

        public override string ToString() => this.Name;

        #endregion
    }
}