namespace PizzaForumApp.Models
{
    using System;
    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
