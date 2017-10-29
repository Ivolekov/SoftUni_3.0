using System.Collections.Generic;
using LearningSystem.Models.BindingModels;
using LearningSystem.Models.ViewModels.Blog;

namespace LearningSystem.Service.Interfaces
{
    public interface IBlogService
    {
        void AddNewArticle(AddArticleBindingModel bind, string userName);
        IEnumerable<ArticleViewModel> GetAllArticles();
    }
}