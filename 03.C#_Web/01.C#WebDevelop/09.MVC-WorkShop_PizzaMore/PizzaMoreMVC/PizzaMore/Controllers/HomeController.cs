namespace PizzaMore.Controllers
{
    using SimpleHttpServer.Models;
    using PizzaMore.Data;
    using PizzaMore.Security;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        private SignInManager signInManager;

        public HomeController()
        {
            this.signInManager = new SignInManager(new PizzaMoreMVCContext());
        }

        [HttpGet]
        public IActionResult Index(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/indexlogged");
            }
            return this.View();
        }

        [HttpGet]
        public IActionResult Indexlogged()
        {
            return this.View();
        }
    }
}
