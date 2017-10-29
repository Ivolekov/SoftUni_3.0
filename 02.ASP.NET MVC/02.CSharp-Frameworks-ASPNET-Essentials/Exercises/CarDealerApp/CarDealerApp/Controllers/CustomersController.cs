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
using CarDealer.Models.BindingModels;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        private CustomersService service;
        private CarDealerContext db = new CarDealerContext();

        public CustomersController()
        {
            this.service = new CustomersService(Data.Context);
        }

        [Route("add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name,BirthDate")] AddCustomerBindingModel AddCustomerBindingModel)
        {
            this.service.AddCustomer(AddCustomerBindingModel);
            return RedirectToAction("Index","Customers/all/ascending");
        }

        // GET: Customers
        [Route("all/{order:regex(ascending|descending)}")]
        public ActionResult Index(string order)
        {
            List<Customer> customers = this.service.OrderCustomers(order);
            return View(customers);
        }

        //[Route("{id}")]
        //public ActionResult Sales(int? id)
        //{
        //    Customer customer = this.db.Customers.Find(id);
        //    return View(customer);
        //}

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            EditCustomerBindingModel model = this.service.GetEditCustomer(id);
            return View(model);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,Name,BirthDate")] EditCustomerBindingModel model)
        {
            this.service.EditCustomer(model);
            return this.RedirectToAction("Index", "Customers/all/ascending");
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
