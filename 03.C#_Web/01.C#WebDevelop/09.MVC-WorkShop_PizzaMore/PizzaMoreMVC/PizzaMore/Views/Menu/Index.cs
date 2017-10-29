namespace PizzaMore.Views.Menu
{
    using System.IO;
    using PizzaMore.ViewModel;
    using SimpleMVC.Interfaces.Generic;
    using System.Text;

    public class Index : IRenderable<PizzaSuggestionViewModel>
    {
        public PizzaSuggestionViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlContnet = new StringBuilder();
            htmlContnet.AppendLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"/home/index\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"/menu/add\">Suggest Pizza</a></li>" +
                "<li><a href=\"/menu/suggestions\">Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"/users/logout\" class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {this.Model.Email}</p>" +
                "</ul> </div></div></nav>");
            htmlContnet.AppendLine(File.ReadAllText("../../content/menu-top.html"));
            htmlContnet.AppendLine("<div class=\"card-deck\">");
            foreach (var pizza in this.Model.PizzaSuggestions)
            {
                htmlContnet.AppendLine("<div class=\"card\">");
                htmlContnet.AppendLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                htmlContnet.AppendLine("<div class=\"card-block\">");
                htmlContnet.AppendLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                htmlContnet.AppendLine($"<p class=\"card-text\"><a href=\"DetailsPizza.exe?pizzaid={pizza.Id}\">Recipe</a></p>");
                htmlContnet.AppendLine("<form method=\"POST\">");
                htmlContnet.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                htmlContnet.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                htmlContnet.AppendLine($"<input type=\"hidden\" name=\"pizzaid\" value=\"{pizza.Id}\" />");
                htmlContnet.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                htmlContnet.AppendLine("</form>");
                htmlContnet.AppendLine("</div>");
                htmlContnet.AppendLine("</div>");
            }
            htmlContnet.AppendLine("</div>");

            htmlContnet.AppendLine(File.ReadAllText("../../content/menu-bottom.html"));

            return htmlContnet.ToString();
        }
    }
}
