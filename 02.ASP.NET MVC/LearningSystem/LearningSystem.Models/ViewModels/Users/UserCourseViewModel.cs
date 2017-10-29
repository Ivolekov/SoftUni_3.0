namespace LearningSystem.Models.ViewModels.Users
{
    using Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class UserCourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade Grade { get; set; }
    }
}
