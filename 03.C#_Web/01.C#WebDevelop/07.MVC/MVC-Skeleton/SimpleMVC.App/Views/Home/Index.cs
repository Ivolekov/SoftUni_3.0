using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>NotesApp</h3>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a>");
            sb.AppendLine("<a href=\"/users/register\">Register Users</a>");
            sb.AppendLine("<a href=\"/users/logout\">Log Out</a>");
            return sb.ToString();
        }
    }
}
