using BookShopSystem.Services;
using BookShopSytem.Models.BindingModels.Books;
using BookShopSytem.Models.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookShopSystem.Web.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookService service;
        public BooksController()
        {
            this.service = new BookService();
        }

        #region Get

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (!this.service.ContainBook(id))
            {
                return this.NotFound();
            }

            DetailedBookVm vm = this.service.GetDetailedBook(id);
            return this.Ok(vm);
        }

        [HttpGet]
        [Route]
        public IHttpActionResult GetSearch(string search)
        {
            if (search == null)
            {
                return this.NotFound();
            }

            IEnumerable<SearchBookVm> vms = this.service.GetSearchedBooks(search);
            return this.Ok(vms);
        }

        #endregion

        #region Post

        [HttpPost]
        [Route]
        public IHttpActionResult Post(AddBookBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.service.CreateBook(bind);
            return this.StatusCode(HttpStatusCode.Created);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!this.service.ContainBook(id))
            {
                return this.NotFound();
            }

            this.service.Deletebook(id);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        #endregion

        #region Put

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, EditBookBm bind)
        {
            if (!this.service.ContainBook(id))
            {
                return this.NotFound();
            }
            bool IsValid;
            this.service.EditBook(id, bind, out IsValid);
            if (!IsValid)
            {
                return this.StatusCode(HttpStatusCode.NotModified);
            }
            return this.Ok();
        }

        #endregion

    }
}
