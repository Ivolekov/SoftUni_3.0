namespace SoftUniGameScore.Services
{
    using System.Linq;
    using ViewModels;
    using System.Collections.Generic;
    using Models;
    using BindingModels;

    public class HomeService : Service
    {
        public AllViewModel GetAllViewModel(string filter, User currentUser)
        {
            AllViewModel allViewModel = new AllViewModel();
            if (string.IsNullOrEmpty(filter) || filter == "all")
            {


                IEnumerable<GamesViewModel> games = this.Context.Games.Select(g => new GamesViewModel()
                {
                    Id = g.Id,
                    Description = g.Description.Substring(0, 300),
                    ImageThumbnail = g.ImageThumbnail,
                    Price = g.Price,
                    Size = g.Size,
                    Title = g.Title
                });


                allViewModel.Games = games;
            }
            else
            {
                IEnumerable<GamesViewModel> games = currentUser.Games.Select(g => new GamesViewModel()
                {
                    Id = g.Id,
                    Description = g.Description.Substring(0, 300),
                    ImageThumbnail = g.ImageThumbnail,
                    Price = g.Price,
                    Size = g.Size,
                    Title = g.Title
                });

                allViewModel.Games = games;
            }
            return allViewModel;
        }

        public void BuyGameForUser(User currentUser, BuyGameBindingModel bind)
        {
            currentUser.Games.Add(this.Context.Games.Find(bind.Id));
            this.Context.SaveChanges();
        }
    }
}
