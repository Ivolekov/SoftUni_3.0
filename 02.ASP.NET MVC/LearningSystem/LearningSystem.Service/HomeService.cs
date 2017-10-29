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

    public class HomeService : Service, IHomeService
    {
        public IEnumerable<CourseViewModel> GetAllCourses()
        {
            IEnumerable<Course> courses = this.Context.Courses;
            IEnumerable<CourseViewModel> vms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);
            return vms;
        }
    }
}
