namespace SoftUniGameScore.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel bind)
        {
            //validations for registretion
            if (!this.service.IsRegisterViewModelValid(bind))
            {
                this.Redirect(response, "/user/register");
                return null;
            }
            //add user to database
            User user = this.service.GetUserFromRegisterBind(bind);
            this.service.RegisterUser(user);
            this.Redirect(response, "/user/login");
            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel bind)
        {
            if (!this.service.IsLoginModelValid(bind))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            User user = this.service.GetUserFromLoginBind(bind);
            this.service.LoginUser(user, session.Id);

            this.Redirect(response, "/home/games");
            return null;
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            this.service.LogoutUser(session.Id, response);
            this.Redirect(response, "/user/login");
        }
    }
}
