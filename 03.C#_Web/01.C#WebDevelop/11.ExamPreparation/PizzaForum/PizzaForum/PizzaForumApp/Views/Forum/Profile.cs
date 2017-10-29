namespace PizzaForumApp.Views.Forum
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

    public class Profile : IRenderable<ProfileViewModel>
    {
        public ProfileViewModel Model { get; set; }

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

            string profile = File.ReadAllText(Constants.ContentPath + Constants.Profile);

            StringBuilder topics = new StringBuilder();
            foreach (var topic in Model.Topics)
            {
                topics.Append("<tr>");
                topics.Append(topic.ToString());
                if (Model.ClickeUserId == Model.CurrentUserId)
                {
                    topics.Append(topic.GetDeleteButton());
                }
                topics.Append("</tr>");
            }
            profile = string.Format(profile, Model.ClickedUsername, topics);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(profile);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
