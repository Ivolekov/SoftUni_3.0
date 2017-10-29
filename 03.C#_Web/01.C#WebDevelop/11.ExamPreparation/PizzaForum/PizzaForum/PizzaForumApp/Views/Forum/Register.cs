namespace PizzaForumApp.Views.Forum
{
    using SimpleMVC.Interfaces;
    using System;
    using System.IO;
    using System.Text;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderPath);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.ContentPath + Constants.Register);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(register);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
