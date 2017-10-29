namespace BookShopSystem.Services
{
    using BookShopSystem.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookShopSytem.Models.ViewModels.Books;
    using BookShopSytem.Models.Entities;
    using AutoMapper;
    using BookShopSytem.Models.BindingModels.Books;

    public class BookService : Service, IBooksService
    {
        public bool ContainBook(int id)
        {
            return this.Context.Books.Find(id) != null;
        }

        public DetailedBookVm GetDetailedBook(int id)
        {
            Book model = this.Context.Books.Find(id);
            DetailedBookVm vm = Mapper.Instance.Map<Book, DetailedBookVm>(model);
            return vm;
        }

        public void CreateBook(AddBookBm bind)
        {
            Book book = Mapper.Instance.Map<AddBookBm, Book>(bind);
            this.Context.Books.Add(book);
            this.Context.SaveChanges();
        }

        public void Deletebook(int id)
        {
            Book book = this.Context.Books.Find(id);
            if (book != null)
            {
                this.Context.Books.Remove(book);
                this.Context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The book do not exist!!");
            }
        }

        public IEnumerable<SearchBookVm> GetSearchedBooks(string search)
        {
            IEnumerable<Book> models = this.Context.Books
                .Where(b => b.Title.Contains(search))
                .Take(10)
                .OrderBy(b => b.Title);

            IEnumerable<SearchBookVm> vms = Mapper.Map<IEnumerable<Book>, IEnumerable<SearchBookVm>>(models);
            return vms;
        }

        public void EditBook(int id, EditBookBm bind, out bool IsValid)
        {
            IsValid = true;
            Book model = this.Context.Books.Find(id);
            model.Title = bind.Title;
            model.Price = bind.Price;
            model.ReleaseDate = DateTime.ParseExact(bind.ReleaseDate, "dd-MM-yyyy", null);
            model.AgeRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), bind.AgeRestriction);
            if (this.Context.Authors.Find(bind.AuthorId) == null)
            {
                IsValid = false;
                return;
            }
            model.Author = this.Context.Authors.Find(bind.AuthorId);
            model.Description = bind.Description;
            model.EditionType = (EditionType)Enum.Parse(typeof(EditionType), bind.EditionType);
            model.Copies = bind.Copies;

            this.Context.SaveChanges();
        }
    }
}
