namespace PizzaForumApp.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utilities;
    using ViewModels;

    public class ForumController : Controller
    {
        private ForumService service;
        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (IsAuthenticated(session.Id, response))
            {
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel model)
        {
            //validations
            if (!this.service.IsRegisterViewModelValid(model))
            {
                this.Redirect(response, "forum/register");
                return null;
            }
            //
            User user = this.service.GetUserFromRegisterBind(model);
            this.service.RegisterUser(user);
            this.Redirect(response, "forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (IsAuthenticated(session.Id, response))
            {
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModels model)
        {
            if (!this.service.IsLoginModelValid(model))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User user = this.service.GetUserFromLoginBind(model);
            this.service.LoginUser(user, session.Id);
            
            this.Redirect(response, "/home/topics");
            return null;
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticatedManager.Logout(response, session.Id);
            this.Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<ProfileViewModel> Profile(HttpSession session, int id)
        {
            User user = AuthenticatedManager.GetAuthenticatedUser(session.Id);

            int currentUser = -1;
            if (user!=null)
            {
                currentUser = user.Id;
            }
            ProfileViewModel topics = this.service.GetProfileViewModel(id, currentUser);
            return this.View(topics);
        }

        private bool IsAuthenticated(string sessionId, HttpResponse response)
        {
            if (AuthenticatedManager.IsAuthenticated(sessionId))
            {
                this.Redirect(response, "/home/topics");
                return true;
            }
            return false;
        }
    }
}
