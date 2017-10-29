namespace SoftUniGameScore.ViewModels
{
    using System;
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public string Trailer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            string template = $"<h1 class=\"display-3\">{this.Title}</h1>\r\n<br/>\r\n\r\n" +
                $"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.Trailer}\"" +
                $"frameborder=\"0\" allowfullscreen></iframe>\r\n\r\n<br/>\r\n<br/>\r\n\r\n" +
                $"<p>{this.Description}</p>\r\n\r\n<p><strong>Price</strong> - {this.Price}&euro;</p>\r\n " +
                $"<p><strong>Size</strong> - {this.Size} GB</p>\r\n<p><strong>" +
                $"Release Date</strong> - {this.ReleaseDate}</p>\r\n\r\n" +
                $"<a class=\"btn btn-outline-primary\" name=\"back\" href=\"/home/games\">Back</a>\r\n"+
                $"<form action=\"/home/buy\" method=\"post\">\r\n <input type=\"number\" name=\"id\" "+
                $"value=\"{this.Id}\" hidden=\"hidden\" />\r\n <br/>\r\n<input type=\"submit\""+
                $"class=\"btn btn-success\" value=\"Buy\" />\r\n</form>\r\n<br/>\r\n<br/>\r\n";
            return template;
        }
    }
}
