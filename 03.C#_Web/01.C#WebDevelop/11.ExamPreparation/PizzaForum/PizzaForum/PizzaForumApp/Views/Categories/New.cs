namespace PizzaForumApp.Views.Categories
{
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;
    public class New : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderPath);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string adminCategoryNew = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoryNew);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(adminCategoryNew);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
