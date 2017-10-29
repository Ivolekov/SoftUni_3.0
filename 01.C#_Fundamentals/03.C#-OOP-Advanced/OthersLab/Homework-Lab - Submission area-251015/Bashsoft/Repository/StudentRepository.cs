namespace Lab.AdvancedCSharp.Bashsoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts;
    using DataStructures;
    using Exceptions;
    using IO;
    using Models;
    using StaticData;

    public class StudentRepository : IDatabase
    {
        #region Constants and Readonly Fields

        private const ConsoleColor LogColor = ConsoleColor.Yellow;

        private const ConsoleColor CourseColor = ConsoleColor.Green;

        private readonly ConsoleColor defaultColor = Console.ForegroundColor;

        #endregion

        #region Private Fields

        private bool isDataInitialized = false;

        private Dictionary<string, Student> students;

        private Dictionary<string, Course> courses;

        private IDataFilter filter;

        private IDataSorter sorter;

        #endregion

        #region Constructors

        public StudentRepository(IDataSorter sorter, IDataFilter filter)
        {
            this.sorter = sorter;
            this.filter = filter;
        }

        #endregion

        #region Public Methods

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitialized);
            }

            OutputWriter.WriteMessageLine("Reading data...", LogColor);

            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitialized);
            }

            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
            OutputWriter.WriteMessageLine("Database dropped!", LogColor);
        }

        public void PrintStudentScoresFromCourse(string courseName, string studentName)
        {
            if (this.IsPossibleStudentQuery(courseName, studentName))
            {
                var student = this.courses[courseName].StudentsByName[studentName];
                OutputWriter.WriteMessageLine($"{student.Name} - {student.MarksByCourseName[courseName]}", this.defaultColor);
            }
        }

        public void PrintAllStudentScoresFromCourse(string courseName)
        {
            if (this.IsPossibleCourseQuery(courseName))
            {
                OutputWriter.WriteMessageLine($"{courseName}:", CourseColor);

                foreach (var student in this.courses[courseName].StudentsByName)
                {
                    this.PrintStudentScoresFromCourse(courseName, student.Key);
                }
            }
        }

        public ISimpleOrderedBag<Course> GetAllCoursesSorted(IComparer<Course> comparer)
        {
            var sortedCourses = new SimpleSortedList<Course>(comparer);
            sortedCourses.AddAll(this.courses.Values);

            return sortedCourses;
        }

        public ISimpleOrderedBag<Student> GetAllStudentsSorted(IComparer<Student> comparer)
        {
            var sortedStudents = new SimpleSortedList<Student>(comparer);
            sortedStudents.AddAll(this.students.Values);

            return sortedStudents;
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsPossibleCourseQuery(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                var marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.IsPossibleCourseQuery(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                var marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        #endregion

        #region PrivateMethods

        private void ReadData(string fileName)
        {
            string[] inputLines;
            string path = $"{SessionData.CurrentPath}\\{fileName}";

            if (File.Exists(path))
            {
                inputLines = InputReader.ReadLines(fileName);
            }
            else
            {
                throw new InvalidPathException();
            }

            string pattern = @"(?'course'[A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+(?'username'[A-Za-z]+\d{2}_\d{2,4})\s*(?'marks'(\s\d+)+)";
            var regex = new Regex(pattern);

            for (int index = 0; index < inputLines.Length; index++)
            {
                try
                {
                    if (!string.IsNullOrEmpty(inputLines[index])
                        && regex.IsMatch(inputLines[index]))
                    {
                        var currentMatch = regex.Match(inputLines[index]);
                        string courseName = currentMatch.Groups["course"].Value;
                        string studentName = currentMatch.Groups["username"].Value;
                        string scoresStr = currentMatch.Groups["marks"].Value;
                        int[] scores = scoresStr
                            .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        if (scores.Any(sc => sc > 100 || sc < 0))
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            continue;
                        }

                        if (scores.Length > Course.NumberOfTasksOnExam)
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                            continue;
                        }

                        if (!this.students.ContainsKey(studentName))
                        {
                            this.students.Add(studentName, new Student(studentName));
                        }

                        if (!this.courses.ContainsKey(courseName))
                        {
                            this.courses.Add(courseName, new Course(courseName));
                        }

                        var course = this.courses[courseName];
                        var student = this.students[studentName];

                        student.EnrollInCourse(course);
                        student.SetMarkOnCourse(courseName, scores);

                        course.EnrollStudent(student);
                    }
                }
                catch (FormatException fex)
                {
                    OutputWriter.DisplayException(fex.Message + $" at line: {index}");
                }
            }

            this.isDataInitialized = true;
            OutputWriter.WriteMessageLine("Data read!", LogColor);
        }

        private bool IsPossibleCourseQuery(string courseName)
        {
            if (this.isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    throw new ArgumentException(
                        ExceptionMessages.InexistingCourseInDatabase);
                }
            }
            else
            {
                throw new ArgumentException(
                    ExceptionMessages.DataNotInitialized);
            }
        }

        private bool IsPossibleStudentQuery(string courseName, string studentName)
        {
            if (this.IsPossibleCourseQuery(courseName)
                && this.courses[courseName].StudentsByName.ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                throw new ArgumentException(
                    ExceptionMessages.InexistingStudentInDatabase);
            }
        }

        #endregion
    }
}
