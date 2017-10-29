namespace PizzaForumApp.Views.Home
{
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Categories : IRenderable<IEnumerable<string>>
    {
        public IEnumerable<string> Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderPath);
            string navigation;
            string currentUser = ViewBag.GetUsername();
            var userEntity = Data.Data.Context.Users.Any(u => u.Username == currentUser && u.IsAdmin);
            if (currentUser != null)
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
                navigation = string.Format(navigation, currentUser);
            }
            else
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            }
            StringBuilder categoriesCollection = new StringBuilder();
            categoriesCollection.Append("<div class=\"container\">");

            foreach (var item in Model)
            {
                categoriesCollection.Append($"<a href=\"/categories/topics?CategoryName={item}\">{item}</a>");
                categoriesCollection.Append("<br>");
            }

            categoriesCollection.Append("</div>");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(categoriesCollection);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
