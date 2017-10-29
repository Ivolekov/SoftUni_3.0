namespace SimpleMVC.App.Controllers
{
    using BindingModels;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generics;
    using System.Collections.Generic;
    using ViewModels;
    using System.Linq;
    using SimpleHttpServer.Models;
    using MVC.Security;

    public class UsersController : Controller
    {
        private SignInManager signManager;

        public UsersController()
        {
            this.signManager = new SignInManager(new UserContext());
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };
            using (var context = new UserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<AllUsernamesViewModel>> All(HttpSession session)
        {
            if (!signManager.IsAuthenticated(session))
            {
                List<AllUsernamesViewModel> list = new List<AllUsernamesViewModel>();
                return Redirect(list.AsEnumerable(), "/users/login");
            }

            List<User> users = null;

            using (var contex = new UserContext())
            {
                users = contex.Users.ToList();
            }

            var viewModel = new List<AllUsernamesViewModel>();
            foreach (var user in users)
            {
                viewModel.Add(new AllUsernamesViewModel()
                {
                    Username = user.Username,
                    Id = user.Id
                });
            }

            return this.View(viewModel.AsEnumerable());
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes.Select(x => new NoteViewModel()
                    {
                        Title = x.Title,
                        Content = x.Content
                    })
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };
                user.Notes.Add(note);
                context.SaveChanges();
            }
            return Profile(model.UserId);
        }

        public IActionResult<GreetViewModel> Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session)
        {
            string username = model.Username;
            string password = model.Password;
            string sessionId = session.Id;
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user.Password == password)
                {
                    Login login = new Login()
                    {
                        IsActive = true,
                        SessionId = sessionId,
                        User = user
                    };
                    context.Logins.Add(login);
                    context.SaveChanges();

                    if (signManager.IsAuthenticated(session))
                    {
                        List<AllUsernamesViewModel> list = new List<AllUsernamesViewModel>();
                        return Redirect("/home/index");
                    }
                    else
                    {
                        return Redirect("/users/login");
                    }
                }    
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session)
        {
            if (signManager.IsAuthenticated(session))
            {
                using (var context = new UserContext())
                {
                    Login login = context.Logins.FirstOrDefault(l=>l.SessionId==session.Id);
                    context.Logins.Remove(login);
                    context.SaveChanges();
                }
                return Redirect("/home/index");
            }
            return View();
        }
    }
}
