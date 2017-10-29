using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using CarDealer.Services;
using CarDealerApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UsersService service;
        public UsersController()
        {
            this.service = new UsersService(Data.Context);
        }

        [HttpGet]
        [Route("register/")]
        public ActionResult Register()
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");
            if (httpCookies != null && AuthenticatedManager.IsAuthenticated(httpCookies.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            return View();
        }

        [HttpPost]
        [Route("register/")]
        public ActionResult Register([Bind(Include = "Username, Email, Password, ConfirmPassword")] RegisterUserBindingModel bind)
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");
            if (httpCookies != null && AuthenticatedManager.IsAuthenticated(httpCookies.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            if (this.ModelState.IsValid && bind.Password == bind.ConfirmPassword)
            {
                this.service.RegisterUser(bind);
                return this.RedirectToAction("Login");
            }
            return this.RedirectToAction("Register");
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");
            if (httpCookies != null && AuthenticatedManager.IsAuthenticated(httpCookies.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([Bind(Include = "Username, Password")]LoginBindingModel bind)
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");

            if (httpCookies != null && AuthenticatedManager.IsAuthenticated(httpCookies.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }

            if (this.ModelState.IsValid && this.service.IsUserExists(bind))
            {
                this.service.LoginUser(bind, Session.SessionID);
                this.Response.SetCookie(new HttpCookie("sessionId", Session.SessionID));
                return this.RedirectToAction("All", "Cars");
            }
            return this.RedirectToAction("Login");
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult Logout()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login");
            }
            AuthenticatedManager.Logout(Request.Cookies.Get("sessionId").Value);
            return this.RedirectToAction("All", "Cars");
        }
    }
}