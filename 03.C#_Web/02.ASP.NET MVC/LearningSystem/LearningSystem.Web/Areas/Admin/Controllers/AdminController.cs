namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Models.ViewModels.Admin;
    using Service;
    using Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Authorize(Roles = "admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private IAdminService service;
        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            AdminPageViewModel vm = this.service.GetAdminPage();
            return this.View(vm);
        }

        [HttpGet]
        [Route("course/add")]
        public ActionResult AddCourse()
        {
            return this.View();
        }

        [HttpGet]
        [Route("course/{id}/edit")]
        public ActionResult EditCourse(int id)
        {
            
            return this.View();
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            return this.View();
        }
    }
}
