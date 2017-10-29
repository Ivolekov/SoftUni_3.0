using System.Collections.Generic;
using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Service.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<CourseViewModel> GetAllCourses();
    }
}