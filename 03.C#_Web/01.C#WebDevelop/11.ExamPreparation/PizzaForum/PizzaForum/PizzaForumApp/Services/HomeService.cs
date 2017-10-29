namespace PizzaForumApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class HomeService : Service
    {
        public IEnumerable<TopicViewModel> GetTopTenLatestTopics()
        {
            IEnumerable<TopicViewModel> topics = Context.Topics.OrderByDescending(m => m.PublishedDate).Take(10)
                .Select(t => new TopicViewModel()
                {
                    Id = t.Id,
                    CategoryName = t.Category.Name,
                    AuthorName = t.Author.Username,
                    Date = t.PublishedDate,
                    RepliesCount = t.Replies.Count,
                    TopicTitle = t.Title
                });

            return topics;
        }

        public IEnumerable<string> GetCategoryNames()
        {
            return this.Context.Categories.Select(c => c.Name);
        }
    }
}
