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
    public class New : IRenderable<IEnumerable<string>>
    {
        public IEnumerable<string> Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderPath);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.GetUsername());
            string newTopics = File.ReadAllText(Constants.ContentPath + Constants.NewTopics);
            
            StringBuilder options = new StringBuilder();
            foreach (var categoryName in Model)
            {
                options.Append($"<option value=\"{categoryName}\">{categoryName}</option>");
            }
            newTopics = string.Format(newTopics, options);

            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterPath);
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(newTopics);
            sb.Append(footer);
            return sb.ToString();
        }
    }
}
