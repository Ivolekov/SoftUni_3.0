namespace LearningSystem.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Blog;
    using Models.EntityModels;
    using AutoMapper;
    using Models.BindingModels;
    using Interfaces;

    public class BlogService : Service, IBlogService
    {
        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            IEnumerable<Article> model = this.Context.Articles;
            IEnumerable<ArticleViewModel> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(model);
            return vms;
        }

        public void AddNewArticle(AddArticleBindingModel bind, string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            Article model = Mapper.Map<AddArticleBindingModel, Article>(bind);
            model.Author = currentUser;
            model.PublishDate = DateTime.Today;
            this.Context.Articles.Add(model);
            this.Context.SaveChanges();
        }
    }
}
