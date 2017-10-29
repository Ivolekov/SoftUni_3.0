namespace LearningSystem.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Admin;
    using Models.EntityModels;
    using Models.ViewModels.Courses;
    using AutoMapper;
    using Interfaces;

    public class AdminService : Service, IAdminService
    {
        public AdminPageViewModel GetAdminPage()
        {
            AdminPageViewModel vm = new AdminPageViewModel();

            IEnumerable<Course> courses = this.Context.Courses;
            IEnumerable<Student> students = this.Context.Students;

            IEnumerable<CourseViewModel> courseVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);
            IEnumerable<AdminPageUserViewModel> userVms = Mapper.Map<IEnumerable<Student>, IEnumerable<AdminPageUserViewModel>>(students);
            vm.Users = userVms;
            vm.Courses = courseVms;
            return vm;
        }
    }
}
