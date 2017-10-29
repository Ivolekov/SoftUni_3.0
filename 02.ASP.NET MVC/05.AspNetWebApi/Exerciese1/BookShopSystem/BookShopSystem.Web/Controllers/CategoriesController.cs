using BookShopSystem.Services;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookShopSystem.Web.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        #region Get

        [HttpGet]
        [Route]
        public IHttpActionResult GetAll()
        {
            if (!this.service.ContainCategories())
            {
                return this.NotFound();
            }
            IEnumerable <CategoryVm> vms= this.service.GetAllCategories();
            return this.Ok(vms);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (!this.service.ContainCategory(id))
            {
                return this.NotFound();
            }
            CategoryVm vm = this.service.GetCategory(id);
            return this.Ok(vm);
        }

        #endregion

        #region Put

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Edit(int id, EditCategoryBm bind)
        {
            if (!this.service.ContainCategory(id))
            {
                return this.NotFound();
            }
            bool IsValid;
            this.service.EditCategory(id, bind, out IsValid);
            if (!IsValid)
            {
                return this.StatusCode(HttpStatusCode.NotModified);
            }
            return this.Ok();
        }

        #endregion

        #region Post

        [HttpPost]
        [Route]
        public IHttpActionResult Post(AddCategoryBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            this.service.CreateCategory(bind);
            return this.StatusCode(HttpStatusCode.Created);
        }


        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            this.service.DeleteCategory(id);
            return this.Ok();
        }

        #endregion
    }
}
