namespace Lab.AdvancedCSharp.Bashsoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Exceptions;
    using StaticData;

    public class Student : IStudent
    {
        #region Private Fields

        private readonly Dictionary<string, ICourse> enrolledCourses;

        private readonly Dictionary<string, double> marksByCourseName;

        private string name;

        #endregion

        #region Constructors

        public Student(string name)
        {
            this.Name = name;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
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

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses => this.enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        #endregion

        #region Public Methods

        public int CompareTo(Student other)
        {
            return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(
                    this.name,
                    course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        public override string ToString() => this.Name;
        
        #endregion

        #region Private Methods

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() /
                (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = (percentageOfSolvedExam * 4) + 2;
            return mark;
        }
        
        #endregion
    }
}
