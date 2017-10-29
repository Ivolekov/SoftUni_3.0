namespace IssueTrackerApp.Controllers
{
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<LoginViewModel> Index(HttpSession session)
        {
            var viewModel = this.service.CheckedForLoginUser(session);
            return this.View(viewModel);
        }
    }
}
