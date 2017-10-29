using CarDealer.Data;
using CarDealer.Models.ViewModels;
using CarDealer.Services;
using CarDealerApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("logs")]
    public class LogsController : Controller
    {
        private LogsService service;

        public LogsController()
        {
            this.service = new LogsService(Data.Context);
        }

        [HttpGet]
        [Route("all/{username?}")]
        public ActionResult All(string username, int? page)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Suppliers");
            }
            AllLogsPageViewModel vm = this.service.GetAllLogsPageVm(username, page); 
            return View(vm);
        }

        [HttpGet]
        [Route("deleteAll")]
        public ActionResult DeleteAll() => this.View();

        [HttpPost]
        [Route("deleteAll")]
        public ActionResult DeleteAlll()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticatedManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Suppliers");
            }

            this.service.DeleteAllLogs();
            return this.RedirectToAction("All", "Suppliers");
        }
    }
}