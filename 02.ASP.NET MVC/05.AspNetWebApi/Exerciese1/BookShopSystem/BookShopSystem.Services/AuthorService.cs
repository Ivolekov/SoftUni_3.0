namespace BookShopSystem.Services
{
    using BookShopSystem.Services;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookShopSytem.Models.ViewModels;
    using BookShopSytem.Models.Entities;
    using AutoMapper;
    using BookShopSytem.Models.BindingModels;
    using BookShopSytem.Models.ViewModels.Authors;

    public class AuthorService : Service, IAuthorsService
    {
        public bool ContainAuthor(int id)
        {
            return this.Context.Authors.Find(id) != null;
        }

        public DetailedAuthorVm GetDetailedAuthor(int id)
        {
            Author model = this.Context.Authors.Find(id);
            DetailedAuthorVm vm = Mapper.Instance.Map<Author, DetailedAuthorVm>(model);
            return vm;
        }

        public void CreateAuthor(AddAuthorBm bind)
        {
            Author author = Mapper.Instance.Map<AddAuthorBm, Author>(bind);
            this.Context.Authors.Add(author);
            this.Context.SaveChanges();
        }

        public IEnumerable<BookAuthorVm> GetAllAuthorBooks(int id)
        {
            IEnumerable<Book> models = this.Context.Authors.Find(id).Books;
            
            IEnumerable<BookAuthorVm> vms = Mapper.Instance.Map<IEnumerable<Book>, IEnumerable<BookAuthorVm>>(models);
            return vms;
        }
    }
}
