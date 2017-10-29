using SimpleMVC.App.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.MVC.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(viewFullQualifedName));
        }
        public ActionResult(string viewFullQualifedName, string location) : this(viewFullQualifedName)
        {
            this.Location = location;
        }
        public IRenderable Action { get; set; }

        public string Location { get; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
