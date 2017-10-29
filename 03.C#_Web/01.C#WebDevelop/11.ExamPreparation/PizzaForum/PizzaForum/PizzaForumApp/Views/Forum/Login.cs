namespace PizzaForumApp.Views.Forum
{
    using SimpleMVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderPath);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            string login = File.ReadAllText(Constants.ContentPath + Constants.Login);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(login);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
