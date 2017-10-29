namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface ICourse : IComparable<Course>
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }

        void EnrollStudent(IStudent student);
    }
}
