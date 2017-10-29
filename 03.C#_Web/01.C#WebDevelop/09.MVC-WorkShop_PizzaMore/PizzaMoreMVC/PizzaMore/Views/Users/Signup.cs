using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Signup : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signup.html");
        }
    }
}
