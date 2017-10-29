namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IRequester
    {
        void PrintStudentScoresFromCourse(string courseName, string studentName);

        void PrintAllStudentScoresFromCourse(string courseName);

        ISimpleOrderedBag<Course> GetAllCoursesSorted(IComparer<Course> comparer);

        ISimpleOrderedBag<Student> GetAllStudentsSorted(IComparer<Student> comparer);
    }
}