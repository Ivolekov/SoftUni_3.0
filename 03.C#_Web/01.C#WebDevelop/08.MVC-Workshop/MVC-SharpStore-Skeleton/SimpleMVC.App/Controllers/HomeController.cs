namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.App.BindingModels;
    using SimpleMVC.App.Models;
    using SimpleMVC.App.Services;
    using SimpleMVC.App.ViewModels;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductsViewModel>> Products(string productName)
        {
            KnivesService service = new KnivesService(Data.Data.Context);
            IEnumerable<ProductsViewModel> viewModel = service.GetProducts(productName);
            return this.View(viewModel);
            //return View(new KnivesService().GetAllKnives());
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(MessageBinding messageBinding)
        {
            if (string.IsNullOrEmpty(messageBinding.Email) || string.IsNullOrEmpty(messageBinding.Subject))
            {
                this.Redirect(new HttpResponse()
                {
                }, "/home/contacts");
            }

            MessageServices service = new MessageServices(Data.Data.Context);
            service.MessageFromBind(messageBinding);

            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Buy(PurchaseViewModel model)
        {
            BuyService service = new BuyService(Data.Data.Context);
            service.AddPurchise(model);
            return this.View("Home", "Index");
        }
    }
}