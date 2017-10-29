namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using Models.ViewModels.Courses;
    using Service;
    using Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Authorize(Roles ="student")]
    [RoutePrefix("courses")]
    public class CoursesController : Controller
    {
        private ICoursesService service;

        public CoursesController(ICoursesService service)
        {
            this.service = service;
        }

        [HttpGet, Route("details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            DetailsCourseViewModel vm = this.service.GetDetrails(id);

            if (vm == null)
            {
                return HttpNotFound();
            }
            return this.View(vm);
        }

       
    }
}
