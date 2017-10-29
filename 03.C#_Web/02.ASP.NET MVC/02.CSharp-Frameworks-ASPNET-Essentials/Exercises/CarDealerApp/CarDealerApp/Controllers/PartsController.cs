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
using CarDealer.Models.ViewModels;

namespace CarDealerApp.Controllers
{
    public class PartsController : Controller
    {
        private PartsService service;
        private CarDealerContext db = new CarDealerContext();

        public PartsController()
        {
            this.service = new PartsService(Data.Context);
        }

        [HttpGet]
        [Route("parts/all")]
        public ActionResult Index()
        {
            IEnumerable<AllPartViewModel> parts = this.service.GetAllParts();
            return View(parts);
        }

        [HttpGet]
        [Route("parts/add")]
        public ActionResult Add()
        {
            var addVM = this.service.GetAddVM();
            return View(addVM);
        }

        [HttpPost]
        [Route("parts/add")]
        public ActionResult Add([Bind(Include = "Name,Price,Quantity,SupplierId")] AddPartBindingModel AddPartBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.AddPart(AddPartBindingModel);
                return RedirectToAction("Index","parts/all");
            }

            var addVM = this.service.GetAddVM();
            return View(addVM);
        }

        [HttpGet]
        [Route("parts/edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditPartViewModel editVm = this.service.GetEditVm(id);
            return View(editVm);
        }

        [HttpPost]
        [Route("parts/edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,Price,Quantity")] EditPartBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.EditPart(bind);
                return RedirectToAction("Index","parts/all");
            }

            EditPartViewModel editVm = this.service.GetEditVm(bind.Id);
            return View(editVm);
        }

        [HttpGet]
        [Route("parts/delete/{id}")]
        public ActionResult Delete(int id)
        {
            DeletePartViewModel dpvm = this.service.GetDeleteVm(id);
            return View(dpvm);
        }

        [HttpPost]
        [Route("parts/delete/{id}")]
        public ActionResult Delete([Bind(Include ="PartId")] DeletePartBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.DeletePartBm(bind);
                return this.RedirectToAction("Index","parts/all");
            }
            var vm = this.service.GetDeleteVm(bind.PartId);
            return View(vm);
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
