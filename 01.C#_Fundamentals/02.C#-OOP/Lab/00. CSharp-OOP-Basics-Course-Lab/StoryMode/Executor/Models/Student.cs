using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Exceptions;
using KeyNotFoundException = Executor.Exceptions.KeyNotFoundException;

namespace Executor.Models
{
    class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get { return this.userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public Dictionary<string, Course> EnrolledCourses
        {
            get { return enrolledCourses; }
        }

        public Dictionary<string, double> MarksByCourseName
        {
            get { return marksByCourseName; }
        }

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                //    this.userName, course.Name));
                //return;
            }
            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new KeyNotFoundException();
                //OutputWriter.DisplayException(ExceptionMessages.NotEnrolledInCourse);
                //return;
            }
            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException();
                //OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                //return;
            }
            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        public double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() /
                (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}
