using Executor.Models;
using System;

namespace Executor.Contracts
{
    public interface Student : IComparable<Student>
    {
        string GetName();
        void EnrollInCourse(Course course);
        void SetMarkOnCourse(string courseName, params int[] scores);
        string GetMarkForCourse(string courseName);
    }
}
