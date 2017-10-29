using LearningSystem.Models.BindingModels;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;
using LearningSystem.Service;
using LearningSystem.Service.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles ="student")]
    [RoutePrefix("users")]
    public class UsersController:Controller
    {
        private IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("enroll")]
        public ActionResult Enroll(int courseId)
        {
            string userName = this.User.Identity.Name;
            Student student = this.service.GetCurrentStudent(userName);
            this.service.EnrollStudentInCourse(courseId, student);
            return this.RedirectToAction("Profile");
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            string userName = this.User.Identity.Name;
            ProfileViewModel vm = this.service.GetProfileVm(userName);
            return this.View(vm);
        }

        [HttpGet]
        [Route("edit")]
        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            EditUsersViewModel vm = this.service.GetEditUsersVm(userName);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(EditUsersBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                string curentUserName = this.User.Identity.Name;
                this.service.EditUser(bind, curentUserName);
                return this.RedirectToAction("Profile");
            }
            string userName = this.User.Identity.Name;
            EditUsersViewModel vm = this.service.GetEditUsersVm(userName);
            return this.View(vm);
        }
    }
}
