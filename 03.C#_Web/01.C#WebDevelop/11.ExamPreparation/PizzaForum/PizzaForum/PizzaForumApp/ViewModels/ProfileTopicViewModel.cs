﻿namespace PizzaForumApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProfileTopicViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public DateTime? PublishDate { get; set; }

        public int RepliesCount { get; set; }

        public override string ToString()
        {
            string representation = $"<td><a href=\"#\">{this.Title}</a></td>\r\n\t\t\t\t<td><a href=\"#\">{this.CategoryName}</a></td>\r\n\t\t\t\t<td>{this.PublishDate}</td>\r\n\t\t\t\t<td>{this.RepliesCount}</td>";
            return representation;
        }

        public string GetDeleteButton()
        {
            string representation = $"<td><a href=\"#\" class=\"btn btn-danger\"/>Delete</a></td>";
            return representation;
        }
    }
}
