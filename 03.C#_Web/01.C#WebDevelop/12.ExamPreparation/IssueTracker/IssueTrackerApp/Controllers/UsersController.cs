namespace IssueTrackerApp.Controllers
{
    using System;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using Utilities;
    using BindingModels;
    using Services;
    using Models;
    using System.Linq;
    using System.Collections.Generic;
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class UsersController : Controller
    {
        private UserService service;

        public UsersController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Login(HttpResponse response, HttpSession session)
        {
            if (IsAuthenticated(session.Id, response))
            {
                return null;
            }
            return this.View(new HashSet<RegistrationVerificationErrorViewModel>());
        }

        [HttpPost]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Login(HttpResponse response, HttpSession session, LoginBindingModel model)
        {
            var errors = this.service.IsLoginModelValid(model);
            if (errors.Any())
            {
                return this.View(errors);
            }

            User user = this.service.GetUserFromLoginBind(model);

            if (this.service.LoginUser(user, session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            this.Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register(HttpResponse response, HttpSession session)
        {
            if (IsAuthenticated(session.Id, response))
            {
                return null;
            }
            return this.View(new HashSet<RegistrationVerificationErrorViewModel>());
        }

        [HttpPost]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register(HttpResponse response, RegisterBindingModel model)
        {
            var errors = this.service.IsValidRegistretion(model);

            if (errors.Any())
            {
                return this.View(errors);
            }

            User user = this.service.GetUserFromRegisterBind(model);
            if (this.service.RegisterUser(user))
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            //this.service.RegisterUser(user);
            this.Redirect(response, "/users/register");
            return null;
        }

        public void Logout(HttpSession session, HttpResponse response)
        {
            this.service.LogoutUser(session.Id, response);
            this.Redirect(response, "/users/login");
        }

        private bool IsAuthenticated(string sessionId, HttpResponse response)
        {
            if (AuthenticatedManager.IsAuthenticated(sessionId))
            {
                this.Redirect(response, "/home/index");
                return true;
            }
            return false;
        }
    }
}
