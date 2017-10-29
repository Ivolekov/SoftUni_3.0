namespace PizzaForumApp.Views.Categories
{
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class Topics : IRenderable<IEnumerable<TopicViewModel>>
    {
        public IEnumerable<TopicViewModel> Model { get; set; }

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
            StringBuilder topicsCollection = new StringBuilder();
            topicsCollection.Append("<div class=\"container\">");

            foreach (var vm in Model)
            {
                topicsCollection.Append(vm);
            }
            topicsCollection.Append("</div>");
            string login = File.ReadAllText(Constants.ContentPath + Constants.Login);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(topicsCollection);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
