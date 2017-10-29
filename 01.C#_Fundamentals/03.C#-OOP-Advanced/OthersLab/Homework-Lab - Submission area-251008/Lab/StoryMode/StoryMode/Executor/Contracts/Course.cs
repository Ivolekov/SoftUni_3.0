using Executor.Contracts;
using Executor.Models;
using System;
using System.Collections.Generic;

namespace Executor.Contracts
{
    public interface Course : IComparable<Course>
    {
        string GetName();
        Dictionary<string, Student> GetStudentByName();
        void EnrollStudent(Student student);
    }
}
