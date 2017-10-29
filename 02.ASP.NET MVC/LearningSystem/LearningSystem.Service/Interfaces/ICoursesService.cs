using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Service.Interfaces
{
    public interface ICoursesService
    {
        DetailsCourseViewModel GetDetrails(int id);
    }
}