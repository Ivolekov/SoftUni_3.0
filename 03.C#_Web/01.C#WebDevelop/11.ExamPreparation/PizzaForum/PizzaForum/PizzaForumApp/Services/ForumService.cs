using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForumApp.BindingModels;
using System.Text.RegularExpressions;
using PizzaForumApp.Models;
using PizzaForumApp.ViewModels;

namespace PizzaForumApp.Services
{
    public class ForumService : Service
    {
        public bool IsRegisterViewModelValid(RegisterUserBindingModel model)
        {
            if (model.Username.Length < 3)
            {
                return false;
            }
            Regex regexForUsername = new Regex("^[a-z0-9]+$");
            if (!regexForUsername.IsMatch(model.Username))
            {
                return false;
            }
            if (!model.Email.Contains("@"))
            {
                return false;
            }
            if (model.Password.Length != 4)
            {
                return false;
            }
            Regex regexForPass = new Regex("^[0-9]+$");
            if (!regexForPass.IsMatch(model.Password))
            {
                return false;
            }
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            if (this.Context.Users.Any(u => u.Username == model.Username || u.Email == model.Email))
            {
                return false;
            }
            return true;
        }

        public bool IsLoginModelValid(LoginUserBindingModels model)
        {
            if (!this.Context.Users.Any(u => (u.Email == model.UsernameOrEmail || u.Username == model.UsernameOrEmail) && u.Password == model.Password))
            {
                return false;
            }
            return true;
        }

        public void LoginUser(User user, string sessionId)
        {
            this.Context.Logins.Add(new Models.Login()
            {
                SessionId = sessionId,
                IsActive = true,
                User = user
            });
            this.Context.SaveChanges();
        }

        public User GetUserFromLoginBind(LoginUserBindingModels model)
        {
            return this.Context.Users.First(u => (u.Email == model.UsernameOrEmail || u.Username == model.UsernameOrEmail)
            && u.Password == model.Password);
        }

        public void RegisterUser(User user)
        {
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel model)
        {
            return new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,

            };
        }

        public ProfileViewModel GetProfileViewModel(int clickedUserId, int currentUserId)
        {
            ProfileViewModel profilevm = new ProfileViewModel()
            {
                ClickeUserId = clickedUserId,
                CurrentUserId = currentUserId,
                ClickedUsername = this.Context.Users.Find(clickedUserId).Username               
            };

            IEnumerable<ProfileTopicViewModel> topics = this.Context.Users.Find(clickedUserId)
                .Topics.Select(t => new ProfileTopicViewModel()
                {
                    CategoryName = t.Category.Name,
                    Id = t.Id,
                    PublishDate = t.PublishedDate,
                    RepliesCount = t.Replies.Count,
                    Title = t.Title
                });

            profilevm.Topics = topics;
            return profilevm;
        }

        public IEnumerable<ProfileTopicViewModel> GetProfileTopicsViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
