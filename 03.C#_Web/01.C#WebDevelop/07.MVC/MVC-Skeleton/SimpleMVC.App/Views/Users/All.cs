using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generics;
using SimpleMVC.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Views.Users
{
    public class All : IRenderable<IEnumerable<AllUsernamesViewModel>>
    {
        //public AllUsernamesViewModel Model { get; set; }

        IEnumerable<AllUsernamesViewModel> IRenderable<IEnumerable<AllUsernamesViewModel>>.Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"../../home/index\">&lt; Home</a>");
            sb.AppendLine("<h3>All Users</h3>");
            sb.AppendLine("<ul>");
            foreach (var user in ((IRenderable<IEnumerable<AllUsernamesViewModel>>)this).Model)
            {
                sb.AppendLine($"<li><a href=\"profile?id={user.Id}\">{user.Username}</a></li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }
}
