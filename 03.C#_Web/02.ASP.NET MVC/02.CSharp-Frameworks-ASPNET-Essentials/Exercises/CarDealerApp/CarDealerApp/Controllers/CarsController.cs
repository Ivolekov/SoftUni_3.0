namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Services;
    using CarDealer.Models.BindingModels;
    using CarDealerApp.Security;

    [RoutePrefix("cars")]
    public class CarsController : Controller
    {
        private CarsService service;
        private CarDealerContext db = new CarDealerContext();

        public CarsController()
        {
            this.service = new CarsService(Data.Context);
        }

        [Route("{make?}")]
        public ActionResult All(string make)
        {
            List<Car> cars = this.service.FindCarByMakeAndOrderDescByTravelDist(make);

            return View(cars);
        }

        [Route("{id:int}/parts")]
        public ActionResult Parts(int? id)
        {
            Car car = this.service.FindCarById(id);
            return View(car);
        }

        [Route("add")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Make, Model, TravelledDistance, Parts")] AddCarBindingModel bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddCar(bind);

                return this.RedirectToAction("All");
            }

            return this.View();
        }
    }
}
