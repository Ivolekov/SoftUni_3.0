namespace PizzaForumApp.Views.Topics
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

    public class Details : IRenderable<DetailsViewModel>
    {
        public DetailsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderPath);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.GetUsername());

            StringBuilder view = new StringBuilder();
            view.Append("<div class=\"container\">");
            view.Append(this.Model.Topic);
            foreach (var reply in this.Model.Replies)
            {
                view.Append(reply);
            }
            string form = File.ReadAllText(Constants.ContentPath + Constants.ReplyForm);
            form = string.Format(form, Model.Topic.Title);
            view.Append(form);
            view.Append("</div>");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(view);
            sb.Append(footer);

            return sb.ToString();


        }
    }
}
