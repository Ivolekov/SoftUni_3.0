using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Services;
using CarDealerApp.Security;
using CarDealer.Models.ViewModels;
using CarDealer.Models.BindingModels;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SupplyerService service;
        private CarDealerContext db = new CarDealerContext();

        public SuppliersController()
        {
            this.service = new SupplyerService(Data.Context);
        }

        [HttpGet]
        [Route("{supplyerType:regex(local|importers)?}")]
        public ActionResult All(string supplyerType)
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");
            if (httpCookies == null || !AuthenticatedManager.IsAuthenticated(httpCookies.Value))
            {
                IEnumerable<SupplierViewModel> supplies = this.service.GetAllSuplyersByType(supplyerType);
                return this.View(supplies);
            }

            User user = AuthenticatedManager.GetAuthenticatedUsers(httpCookies.Value);
            ViewBag.Username = user.Username;
            IEnumerable<SuplierAllViewModel> vm = this.service.GetAllSupplierByTypeForUser(supplyerType);
            return View("AllSuppliersForUser", vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            var httpCookies = this.Request.Cookies.Get("sessionId");
            if (httpCookies == null || !AuthenticatedManager.IsAuthenticated(httpCookies.Value))
            {
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([Bind(Include = "Name,IsImporter")] AddSupplierBindingModel bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }
            User loggedInUser = AuthenticatedManager.GetAuthenticatedUsers(httpCookie.Value);
            this.service.AddSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            EditSupplierViewModel vm = this.service.GetEditSupplierVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id,Name,IsImporter")] EditSupplierBindingModel bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (!this.ModelState.IsValid)
            {
                EditSupplierViewModel vm = this.service.GetEditSupplierVm(bind.Id);
                return this.View(vm);
            }

            User loggedInUser = AuthenticatedManager.GetAuthenticatedUsers(httpCookie.Value);

            this.service.EditSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            DeleteSuplierViewModel vm = this.service.GetDeleteSupplierVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")]DeleteSupplierBindingModel bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (!this.ModelState.IsValid)
            {
                DeleteSuplierViewModel vm = this.service.GetDeleteSupplierVm(bind.Id);
                return this.View(vm);
            }

            User loggedInUser = AuthenticatedManager.GetAuthenticatedUsers(httpCookie.Value);

            this.service.DeleteSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }
    }
}
