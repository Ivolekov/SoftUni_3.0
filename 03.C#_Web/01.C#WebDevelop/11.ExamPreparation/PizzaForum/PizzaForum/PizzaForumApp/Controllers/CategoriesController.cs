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

    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User activeUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            AllViewModel model = this.service.GetAllViewModel(activeUser);
            return this.View(model);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User activeUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, NewCategoryBindingModel model)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
            }

            User activeUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            if (!this.service.IsNewCategoryValid(model))
            {
                this.Redirect(response, "/categories/new");
            }
            //Category category = this.service.GetCategoryFromBind(model);
            this.service.AddNewCategory(model);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public void Delete(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
            }

            User activeUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            this.service.DeleteCategory(id);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
            }

            User activeUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            EditCategoryViewModel viewModel = this.service.GetEditCategoryVM(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult<EditCategoryViewModel> Edit(HttpResponse response, HttpSession session, EditCategoryBindingModel bind)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
            }

            User activeUser = AuthenticatedManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            this.service.EditCategoryEntity(bind);
            this.Redirect(response, "/categories/all");
            return null;
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicViewModel>> Topics(HttpSession session, string categoryName)
        {
            AuthenticatedManager.GetAuthenticatedUser(session.Id);

            IEnumerable<TopicViewModel> topics = this.service.GetCategoryTopicsViewModels(categoryName);

            return this.View(topics);
        }
    }
}
