namespace LearningSystem.Models.ViewModels.Admin
{
    using Courses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AdminPageViewModel
    {
        //public AdminPageViewModel()
        //{
        //    this.Courses = new HashSet<CourseViewModel>();
        //    this.Users = new HashSet<AdminPageUserViewModel>();
        //}
        public IEnumerable<CourseViewModel> Courses { get; set; }

        public IEnumerable<AdminPageUserViewModel> Users { get; set; }
    }
}
