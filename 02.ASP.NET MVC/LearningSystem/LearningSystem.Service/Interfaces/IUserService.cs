using LearningSystem.Models.BindingModels;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;

namespace LearningSystem.Service.Interfaces
{
    public interface IUserService
    {
        void EditUser(EditUsersBindingModel bind, string curentUserName);
        void EnrollStudentInCourse(int courseId, Student student);
        Student GetCurrentStudent(string userName);
        EditUsersViewModel GetEditUsersVm(string userName);
        ProfileViewModel GetProfileVm(string userName);
    }
}