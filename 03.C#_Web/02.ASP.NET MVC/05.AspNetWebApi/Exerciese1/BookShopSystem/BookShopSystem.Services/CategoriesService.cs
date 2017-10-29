using AutoMapper;
using BookShopSystem.Services.Contracts;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.Entities;
using BookShopSytem.Models.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Services
{
    public class CategoriesService : Service, ICategoriesService
    {
        public bool ContainCategories()
        {
            return this.Context.Categories != null;
        }

        public IEnumerable<CategoryVm> GetAllCategories()
        {
            IEnumerable<Category> model = this.Context.Categories;
            IEnumerable<CategoryVm> vms = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<CategoryVm>>(model);
            return vms;
        }

        public bool ContainCategory(int id)
        {
            return this.Context.Categories.Find(id) != null;
        }

        public CategoryVm GetCategory(int id)
        {
            Category model = this.Context.Categories.Find(id);
            CategoryVm vm = Mapper.Instance.Map<Category, CategoryVm>(model);
            return vm;
        }

        public void CreateCategory(AddCategoryBm bind)
        {
            Category category = Mapper.Instance.Map<AddCategoryBm, Category>(bind);
            var categoryNames = this.Context.Categories.Select(c => c.Name);
            if (!categoryNames.Contains(bind.Name))
            {
                this.Context.Categories.Add(category);
                this.Context.SaveChanges();
            }
        }

        public void EditCategory(int id, EditCategoryBm bind, out bool isValid)
        {
            isValid = true;
            Category model = this.Context.Categories.Find(id);
            var category = this.Context.Categories.Any(c => c.Name == bind.Name);
            if (category)
            {
                isValid = false;
                return;
            }
            model.Name = bind.Name;
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = this.Context.Categories.Find(id);
            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }
    }
}
