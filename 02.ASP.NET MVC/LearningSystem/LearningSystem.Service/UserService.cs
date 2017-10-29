namespace LearningSystem.Service
{
    using System;
    using Microsoft.AspNet.Identity;
    using LearningSystem.Models.EntityModels;
    using System.Linq;
    using Models.ViewModels.Users;
    using AutoMapper;
    using System.Collections;
    using System.Collections.Generic;
    using Models.BindingModels;
    using Interfaces;

    public class UserService : Service, IUserService
    {
        public Student GetCurrentStudent(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            Student student = this.Context.Students.FirstOrDefault(s=>s.User.Id == user.Id);
            return student;
        }

        public void EnrollStudentInCourse(int courseId, Student student)
        {
            Course waltedCourse = this.Context.Courses.Find(courseId);
            student.Courses.Add(waltedCourse);
            this.Context.SaveChanges();
        }

        public ProfileViewModel GetProfileVm(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            ProfileViewModel vm = Mapper.Map<ApplicationUser, ProfileViewModel>(currentUser);
            Student currenStudent = this.Context.Students.FirstOrDefault(s=>s.User.Id == currentUser.Id);
            vm.EnrolledCourses = Mapper.Map<IEnumerable<Course>, IEnumerable<UserCourseViewModel>>(currenStudent.Courses);
            return vm;
        }

        public EditUsersViewModel GetEditUsersVm(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            EditUsersViewModel vm = Mapper.Map<ApplicationUser, EditUsersViewModel>(user);
            return vm;
        }

        public void EditUser(EditUsersBindingModel bind, string curentUserName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == curentUserName);
            user.Name = bind.Name;
            user.Email = bind.Email;
            this.Context.SaveChanges();
        }
    }
}
