using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForumApp.BindingModels;
using PizzaForumApp.Models;
using PizzaForumApp.ViewModels;
using SimpleHttpServer.Models;

namespace PizzaForumApp.Services
{
    public class CategoriesService : Service
    {
        public AllViewModel GetAllViewModel(User activeUser)
        {
            AllViewModel allViewModel = new AllViewModel();
            //LoginUserViewModel loggedin = new LoginUserViewModel()
            //{
            //    Username = activeUser.Username
            //};
            IEnumerable<AllCategoryViewModel> categories = this.Context.Categories.Select(c => new AllCategoryViewModel()
            {
                Id = c.Id,
                CategoryName = c.Name
            });

            //allViewModel.User = loggedin;
            allViewModel.Categories = categories;

            return allViewModel;
        }

        public bool IsNewCategoryValid(NewCategoryBindingModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return false;
            }
            return true;
        }

        //public Category GetCategoryFromBind(NewCategoryBindingModel model)
        //{
        //    return this.Context.Categories.First(c => c.Name == model.Name);
        //}

        public void AddNewCategory(NewCategoryBindingModel model)
        {
            this.Context.Categories.Add(new Category()
            {
                Name = model.Name
            });
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            //TODO test
            this.Context.Categories.Remove(this.Context.Categories.Find(id));
            this.Context.SaveChanges();
        }

        public EditCategoryViewModel GetEditCategoryVM(int id)
        {
            Category category = Data.Data.Context.Categories.Find(id);
            return new EditCategoryViewModel()
            {
                CategoryName = category.Name,
                Id = id
            };
        }

        public void EditCategoryEntity(EditCategoryBindingModel bind)
        {
            Category category = Data.Data.Context.Categories.Find(bind.CategoryId);
            if (category!=null)
            {
                category.Name = bind.CategoryName;
            }
            Context.SaveChanges();
        }

        internal IEnumerable<TopicViewModel> GetCategoryTopicsViewModels(string categoryName)
        {
            return this.Context.Categories.FirstOrDefault(t => t.Name == categoryName)
                .Topics
                .Select(t=>new TopicViewModel()
                {
                    Id = t.Id,
                    AuthorName = t.Author.Username,
                    CategoryName = t.Category.Name,
                    Date = t.PublishedDate,
                    RepliesCount= t.Replies.Count,
                    TopicTitle = t.Title
                });
        }
    }
}
