namespace LearningSystem.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Courses;
    using Models.EntityModels;
    using AutoMapper;
    using Interfaces;

    public class CoursesService : Service, ICoursesService
    {
        public DetailsCourseViewModel GetDetrails(int id)
        {
            Course course = this.Context.Courses.Find(id);
            if (course == null)
            {
                return null;
            }

            DetailsCourseViewModel vm = Mapper.Map<Course, DetailsCourseViewModel>(course);
            return vm;
        }
    }
}
