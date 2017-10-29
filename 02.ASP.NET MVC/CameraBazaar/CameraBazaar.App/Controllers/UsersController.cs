namespace CameraBazaar.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using CameraBazaar.Data;
    using CameraBazaar.Models.EntityModels;
    using CameraBazaar.Service;
    using Models.BindingModels.Users;
    using Security;

    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private UsersService service;
        private CameraBazaarContext db;

        public UsersController()
        {
            this.service = new UsersService();
            this.db = new CameraBazaarContext();
            
        }
        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            //this.db.Database.Initialize(true);
            User user = this.db.Users.FirstOrDefault(u => u.Username == "pesho" || u.Email == "pesho@mail.com");
            var httpCookies = this.Request.Cookies.Get("sessionId");
            //if (httpCookies != null && SignInManager.IsAuthenticated(httpCookies.Value))
            {

            }
            return this.View();
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register([Bind(Include = "Username, Email, Password, Phone, ConfirmPassword")] RegisterUserBindingModel bind)
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");
            //if (httpCookies != null && SignInManager.IsAuthenticated(httpCookies.Value))
            {

            }
            if (this.ModelState.IsValid && bind.Password == bind.ConfirmPassword)
            {
               // User user = this.db.Users.FirstOrDefault(u => u.Username == "pesho" || u.Email == "pesho@mail.com");
                this.service.RegisterUser(bind);
                return this.RedirectToAction("Login");
            }
            //User user = new User
            //{
            //    Email = bind.Email,
            //    Phone = bind.Phone,
            //    Password = bind.Password,
            //    Username = bind.Username
            //};

            //if (ModelState.IsValid)
            //{
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //    return RedirectToAction("Login", "Users");
            //}
            return this.RedirectToAction("Register");
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
    }
}
