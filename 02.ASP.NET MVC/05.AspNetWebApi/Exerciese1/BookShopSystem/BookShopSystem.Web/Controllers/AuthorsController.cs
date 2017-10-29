using BookShopSystem.Services;
using BookShopSystem.Services.Contracts;
using BookShopSytem.Models.BindingModels;
using BookShopSytem.Models.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookShopSystem.Web.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private AuthorService service;

        public AuthorsController()
        {
            this.service = new AuthorService();
        }

        #region Get

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (!this.service.ContainAuthor(id))
            {
                return this.NotFound();
            }
            DetailedAuthorVm vm = this.service.GetDetailedAuthor(id);
            return this.Ok(vm);
        }

        [HttpGet]
        [Route("{id}/books")]
        public IHttpActionResult GetBooks(int id)
        {
            if (!this.service.ContainAuthor(id))
            {
                return this.NotFound();
            }

            IEnumerable<BookAuthorVm> vms = this.service.GetAllAuthorBooks(id);
            return this.Ok(vms);
        }

        #endregion

        #region POST

        [HttpPost]
        [Route]
        public IHttpActionResult Post(AddAuthorBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.service.CreateAuthor(bind);
            return this.StatusCode(HttpStatusCode.Created);
        }

        #endregion       

    }
}
