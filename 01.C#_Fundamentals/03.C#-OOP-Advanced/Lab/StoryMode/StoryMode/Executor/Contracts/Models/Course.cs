namespace Executor.Models.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface Course  : IComparable<Course>
    {
        String Name { get; }

        IReadOnlyDictionary<String, Student> StudentsByName { get; }

        void EnrollStudent(Student student);
    }
}
