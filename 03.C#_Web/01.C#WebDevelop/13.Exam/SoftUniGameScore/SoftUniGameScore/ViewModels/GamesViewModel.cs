namespace SoftUniGameScore.ViewModels
{
    public class GamesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Size { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageThumbnail { get; set; }

        public override string ToString()
        {
            string template = $"<div class=\"card col-xl-4 centered thumbnail\">\r\n\r\n                        <img class=\"card-image-top img-fluid img-thumbnail\" src=\"{this.ImageThumbnail}\" alt=\"Game Cover\">\r\n\r\n                        <div class=\"card-block\">\r\n                            <h4 class=\"card-title\">{this.Title}</h4>\r\n                            <p class=\"card-text\"><strong>Price</strong> - {this.Price}&euro;</p>\r\n                            <p class=\"card-text\"><strong>Size</strong> - {this.Size} GB</p>\r\n                            <p class=\"card-text\">{this.Description}</p>\r\n                        </div>\r\n\r\n                        <div class=\"card-footer\">\r\n                            <a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/game/info?id={this.Id}\">Info</a>\r\n                        </div>\r\n\r\n                    </div>";
            
            return template;
        }
    }
}
