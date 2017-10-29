namespace PizzaMore.Controllers
{
    using System.Linq;
    using AutoMapper;
    using PizzaMore.BindingModels;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new PizzaMoreMVCContext());
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signup(SignupBindingModel model, HttpResponse response)
        {
            using (PizzaMoreMVCContext context = new PizzaMoreMVCContext())
            {
                User userEntity = new User()
                {
                    Email = model.SignUpEmail,
                    Password = model.SignUpPassword
                };

                context.Users.Add(userEntity);
                context.SaveChanges();
            }
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signin(SignInBindingModel model, HttpSession session, HttpResponse response)
        {
            using (PizzaMoreMVCContext context = new PizzaMoreMVCContext())
            {
                User currenUser =
                    context.Users.FirstOrDefault(u => u.Password == model.SignInPassword &&
                    u.Email == model.SignInEmail);
                if (currenUser!=null)
                {
                    Session sessionEntity = new Session()
                    {
                        SessionId = session.Id,
                        IsActive = true,
                        User = currenUser
                    };
                    context.Sessions.Add(sessionEntity);
                    context.SaveChanges();
                    this.Redirect(response,"/home/index");
                }
                
            }
            
            return this.View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.signInManager.Logout(response, session.Id);
            this.Redirect(response,"/home/index");
            return null;
        }
    }
}
