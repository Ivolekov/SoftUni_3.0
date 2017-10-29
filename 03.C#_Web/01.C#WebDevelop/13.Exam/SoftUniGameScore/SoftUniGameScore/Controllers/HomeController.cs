namespace SoftUniGameScore.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using Utilities;
    using ViewModels;

    public class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<AllViewModel> Games(HttpSession session, HttpResponse response, string filter)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            User currentUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            var model = this.service.GetAllViewModel(filter, currentUser);
            return this.View(model);
        }

        [HttpPost]
        public void Buy(HttpResponse response, HttpSession session, BuyGameBindingModel bind)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
            }
            User currentUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            this.service.BuyGameForUser(currentUser, bind);
            this.Redirect(response, "/home/games?filter=owned");
        }
    }
}
