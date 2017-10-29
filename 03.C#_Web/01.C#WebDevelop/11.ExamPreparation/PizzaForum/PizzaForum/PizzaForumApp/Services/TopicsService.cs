namespace PizzaForumApp.Services
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BindingModels;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    public class TopicsService : Service
    {
        public IEnumerable<string> GetCategoryNames()
        {
            return Context.Categories.Select(c => c.Name);
        }

        public void AddNewTopic(NewTopicBindingModel bind, User user)
        {
            Category category = Context.Categories.FirstOrDefault(c => c.Name == bind.Category);
            Topic topic = new Topic()
            {
                Author = user,
                Content = bind.Content,
                Title = bind.Title,
                PublishedDate = DateTime.Now,
                Category = category
            };
            Context.Topics.Add(topic);
            Context.SaveChanges();
        }

        public bool IsNewTopicValid(NewTopicBindingModel bind)
        {
            if (bind.Title.Length>30 || bind.Content.Length>5000)
            {
                return false;
            }
            return true;
        }

        public DetailsViewModel GetDetailsViewModel(int id)
        {
            Topic topic = this.Context.Topics.Find(id);
            DetailsTopicViewModel topicViewModel = new DetailsTopicViewModel()
            {
                Title = topic.Title,
                AuthorName = topic.Author.Username,
                Content = topic.Content,
                PublishDate = topic.PublishedDate
            };
            IEnumerable<DetailsReplyViewModel> reply = topic.Replies.Select(r=>new DetailsReplyViewModel
            {
                AuthorName = r.Author.Username,
                Content = r.Content,
                ImageUrl = r.ImageUrl,
                PublishDate = r.PublishedDate
            });

            return new DetailsViewModel
            {
                Topic = topicViewModel,
                Replies = reply
            };
        }

        public void AddNewReply(DetailsReplyBindingModel bind, User user)
        {
            Topic topic = this.Context.Topics.FirstOrDefault(t=>t.Title == bind.TopicTitle);
            this.Context.Replies.Add(new Reply()
            {
                PublishedDate = DateTime.Now,
                ImageUrl = bind.imageUrl,
                Author = user,
                Content = bind.Content,
                Topic = topic
            });
            this.Context.SaveChanges();
        }
    }
}
