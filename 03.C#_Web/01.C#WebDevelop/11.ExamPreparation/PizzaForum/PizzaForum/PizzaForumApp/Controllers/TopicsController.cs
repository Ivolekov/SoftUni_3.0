namespace PizzaForumApp.Controllers
{
    using BindingModels;
    using Models;
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
    using Utilities;
    using ViewModels;

    public class TopicsController : Controller
    {
        private TopicsService service;

        public TopicsController()
        {
            this.service = new TopicsService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<string>> New(HttpSession session, HttpResponse response)
        {
            User currentUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);

            if (currentUser==null)
            {
                this.Redirect(response, "/home/topics");
            }

            IEnumerable<string> categoryName = this.service.GetCategoryNames();
            return this.View(categoryName);
        }

        [HttpPost]
        public void New(HttpSession session, HttpResponse response, NewTopicBindingModel bind )
        {
            User user = AuthenticatedManager.GetAuthenticatedUser(session.Id);

            if (user == null)
            {
                this.Redirect(response, "/home/topics");
                return;
            }
            if (!service.IsNewTopicValid(bind))
            {
                this.Redirect(response, "/topics/new");
                return;
            }
            this.service.IsNewTopicValid(bind);
            this.service.AddNewTopic(bind, user);

            this.Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<DetailsViewModel> Details(int id, HttpSession session, HttpResponse response)
        {
            User user = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (user==null)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            DetailsViewModel viewModel = this.service.GetDetailsViewModel(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public void Details(HttpRequest request, HttpSession session, HttpResponse response, DetailsReplyBindingModel bind)
        {
            User user = AuthenticatedManager.GetAuthenticatedUser(session.Id);

            if (user==null)
            {
                this.Redirect(response, "/home/topics");
                return;
            }

            this.service.AddNewReply(bind, user);
            this.Redirect(response, request.Url);
        }
    }
}
