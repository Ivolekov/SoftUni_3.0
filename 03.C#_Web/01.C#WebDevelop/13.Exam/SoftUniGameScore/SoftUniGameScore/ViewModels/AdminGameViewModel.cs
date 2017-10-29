namespace SoftUniGameScore.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AdminGameViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public override string ToString()
        {
            string template = $"<tr>\r\n                        <td>{this.Title}</td>\r\n                        <td>{this.Size} GB</td>\r\n                        <td>{this.Price} &euro;</td>\r\n                        <td>\r\n                            <a href=\"/game/edit?id={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n                            <a href=\"/game/delete?id={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n                        </td>\r\n                    </tr>";
            return template;
        }
    }
}
