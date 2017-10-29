using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();
            StringBuilder sb = new StringBuilder();
            //1
            //var students = context.Homework
            //    .Select(s => new
            //    {
            //        StudentName = s.Student.Name,
            //        Content = s.Content,
            //        ContentType = s.Type
            //    });

            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.StudentName} {s.Content} {s.ContentType}");
            //}

            //2
            //var courses = context.Courses
            //    .OrderBy(c => c.StartDate)
            //    .ThenByDescending(c => c.EndDate)
            //    .Select(c => new
            //    {
            //        CourseName = c.Name,
            //        CourseDesc = c.Description,
            //        Resourses = c.Resourses.Select(r => new
            //        {
            //            ResourseName = r.Name,
            //            ResourseType = r.Type,
            //            ResourseURL = r.URL
            //        })
            //    });

            //foreach (var course in courses)
            //{
            //    Console.Write($"{course.CourseName} {course.CourseDesc} ");

            //    foreach (var resourse in course.Resourses)
            //    {
            //        Console.WriteLine($"{resourse.ResourseName} {resourse.ResourseType} {resourse.ResourseURL}");
            //    }
            //}

            //03

        }
    }
}
