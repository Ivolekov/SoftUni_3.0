namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IStudent : IComparable<Student>
    {
        string Name { get; }

        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(ICourse course);

        void SetMarkOnCourse(string courseName, params int[] scores);
    }
}
