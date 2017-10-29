using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Contracts;
using Executor.Models.Contracts;

namespace Executor.Repository.Contacts
{
    using Executor.Contracts.DataStructures;

    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string username);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<Course> GetAllCoursesSorted(IComparer<Course> cmp);

        ISimpleOrderedBag<Student> GetAllStudentsSorted(IComparer<Student> cmp);
    }
}
