namespace SimpleMVC.App.MVC.Controllers
{
    using Interfaces;
    using Interfaces.Generics;
    using ViewEngine;
    using ViewEngine.Generic;
    using System.Runtime.CompilerServices;
    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName =
                string.Format("{0}.{1}.{2}.{3}",
                            MvcContext.Current.AssemblyName,
                            MvcContext.Current.ViewsFolder,
                            controllerName,
                            callee);

            return new ActionResult(fullQualifedName);
        }
        protected IActionResult<T> View<T>(T model, [CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName =
                string.Format("{0}.{1}.{2}.{3}",
                            MvcContext.Current.AssemblyName,
                            MvcContext.Current.ViewsFolder,
                            controllerName,
                            callee);

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected IActionResult View(string controller, string action)
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName =
                string.Format("{0}.{1}.{2}.{3}",
                            MvcContext.Current.AssemblyName,
                            MvcContext.Current.ViewsFolder,
                            controller,
                            action);

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult<T> View<T>(string controller, string action, T model)
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName =
                string.Format("{0}.{1}.{2}.{3}",
                            MvcContext.Current.AssemblyName,
                            MvcContext.Current.ViewsFolder,
                            controller,
                            action);

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected IActionResult Redirect(string location, [CallerMemberName]string callee = "")
        {
            string controlerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controlerName,
                callee);
            return new ActionResult(fullQualifedName, location);
        }

        protected IActionResult<T> Redirect<T>(T model, string location, [CallerMemberName]string callee = "")
        {
            string controlerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controlerName,
                callee);
            return new ActionResult<T>(fullQualifedName, model, location);
        }
    }
}
