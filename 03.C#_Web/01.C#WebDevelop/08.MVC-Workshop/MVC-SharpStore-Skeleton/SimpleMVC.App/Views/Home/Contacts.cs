using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Contacts : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/contact.html");

        }
    }
}
