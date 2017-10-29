namespace PizzaForumApp.Controllers
{
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
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
        public IActionResult<IEnumerable<TopicViewModel>> Topics(HttpSession session)
        {
            AuthenticatedManager.GetAuthenticatedUser(session.Id); 
            IEnumerable<TopicViewModel> topics = service.GetTopTenLatestTopics();
            return this.View(topics);
        }

        [HttpGet]
        public IActionResult<IEnumerable<string>> Categories(HttpSession session)
        {
            AuthenticatedManager.GetAuthenticatedUser(session.Id);
            IEnumerable<string> categoryNames = this.service.GetCategoryNames();
            return this.View(categoryNames);
        }
    }
}
