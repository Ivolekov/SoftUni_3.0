using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Service;
using LearningSystem.Service.Interfaces;
using LearningSystem.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = "student")]
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private IHomeService services;
        public HomeController(IHomeService service)
        {
            this.services = service;
        }

        [AllowAnonymous]
        [Route]
        public ActionResult Index()
        {
            IEnumerable<CourseViewModel> vms = this.services.GetAllCourses();
            return View(vms);
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}