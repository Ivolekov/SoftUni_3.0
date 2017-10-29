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
    [RoutePrefix("Sales")]
    public class SalesController : Controller
    {
        private SalesService service;
        private CarDealerContext db = new CarDealerContext();

        public SalesController()
        {
            this.service = new SalesService(Data.Context);
        }

        [HttpGet]
        [Route]
        public ActionResult All()
        {
            List<Sale> sales = this.service.GetAllSales();
            return View(sales);
        }


        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        [HttpGet]
        [Route("Discount/{percent?}")]
        public ActionResult Discount(double? percent)
        {
            List<Sale> sales = this.service.GetDiscountSales(percent);
            return View(sales);
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticatedManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }
            AddSaleViewModel vm = this.service.GetSalesViewModel();
            return View(vm);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([Bind(Include = "CustomerId, CarId, Discount")] AddSaleBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                AddSalesConfirmationViewModel confirmationVm = this.service.GetSalesConfirmationViewModel(bind);
                return RedirectToAction("AddConfirmation", confirmationVm);
            }
            AddSaleViewModel vm = this.service.GetSalesViewModel();
            return View(vm);
        }

        [HttpGet]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(AddSalesConfirmationViewModel vm)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticatedManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }
            return View(vm);
        }

        [HttpPost]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(AddSaleBindingModel bind)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticatedManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }
            this.service.AddSale(bind);
            return this.RedirectToAction("All");
        }
    }
}
