namespace Shouter.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }
    }
}
