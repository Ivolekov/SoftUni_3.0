namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using LearningSystem.Service;
    using Models.BindingModels;
    using Models.ViewModels.Blog;
    using Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    [RouteArea("blog")]
    //[RoutePrefix("blog")]
    [Authorize(Roles ="student")]
    public class BlogController : Controller
    {
        private IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }

        [Route("AllArticles")]
        public ActionResult AllArticles()
        {
            IEnumerable<ArticleViewModel> vms = this.service.GetAllArticles();
            return this.View(vms);
        }


        [Authorize(Roles = "blogAuthor")]
        [ChildActionOnly]
        public ActionResult CreationVisualize()
        {
            return this.PartialView("_AddButton");
        }

        [HttpGet]
        [Authorize(Roles = "blogAuthor")]
        [Route("articles/add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "blogAuthor")]
        [Route("articles/add")]
        public ActionResult Add(AddArticleBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                string userName = this.User.Identity.Name;
                this.service.AddNewArticle(bind, userName);
                return this.RedirectToAction("AllArticles");
            }
            return this.View();
        }
    }
}
