namespace LearningSystem.Models.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProfileViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<UserCourseViewModel> EnrolledCourses { get; set; }
    }
}
