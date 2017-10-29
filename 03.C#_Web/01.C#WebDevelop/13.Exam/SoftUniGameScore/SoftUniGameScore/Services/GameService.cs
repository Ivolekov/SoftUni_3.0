namespace SoftUniGameScore.Services
{

    using BindingModels;
    using System.Linq;
    using Models;
    using ViewModels;
    using System.Collections.Generic;

    public class GameService : Service
    {
        public GameDetailsViewModel GetGameDetailsViewModel(int id)
        {
            Game game = this.Context.Games.Find(id);
            GameDetailsViewModel gameDetailsVm = new GameDetailsViewModel()
            {
                Id = game.Id,
                Description = game.Description,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Size = game.Size,
                Title = game.Title,
                Trailer = game.Trailer
            };
            return gameDetailsVm;
        }

        //todo buy
        public void BuyGame(GameDetailsViewModel model, User user)
        {
            Game game = this.Context.Games.FirstOrDefault(g => g.Id == model.Id);
            user.Games.Add(game);
            this.Context.SaveChanges();
        }
        //todo buy
        public Game GetGameFromViewModel(GameDetailsViewModel model)
        {
            return this.Context.Games.FirstOrDefault(g => g.Id == model.Id);
        }

        public AllAdminGameViewModel GetAllAdminViewModel()
        {
            AllAdminGameViewModel allAdminGameVM = new AllAdminGameViewModel();

            IEnumerable<AdminGameViewModel> games = this.Context.Games.Select(g => new AdminGameViewModel()
            {
                Id = g.Id,
                Price = g.Price,
                Size = g.Size,
                Title = g.Title
            });

            allAdminGameVM.Games = games;
            return allAdminGameVM;
        }

        public bool IsAddGameViewModelValid(AddGameBindingModel bind)
        {
            if (bind.Title.Length > 100 && bind.Title.Length < 3)
            {
                return false;
            }

            if (bind.Price < 0)
            {
                return false;
            }

            if (bind.Size < 0)
            {
                return false;
            }

            if (bind.Title.Length != 11)
            {
                return false;
            }

            if (bind.Description.Length < 20)
            {
                return false;
            }

            //if (bind.Thumbnail.StartsWith("http://"))
            //{
            //    return false;
            //}
            return true;
        }

        public Game GetGameFromAddGameBind(AddGameBindingModel bind)
        {
            return new Game()
            {
                Description = bind.Description,
                ImageThumbnail = bind.Thumbnail,
                Price = bind.Price,
                ReleaseDate = bind.ReleaseDate,
                Size = bind.Size,
                Title = bind.Title,
                Trailer = bind.Trailer,
            };
        }

        public EditViewModel GetEditViewModel(int id)
        {
            Game game = this.Context.Games.Find(id);
            EditViewModel EditVm = new EditViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageThumbnail,
                Price = game.Price,
                Size = game.Size,
                Trailer = game.Trailer
            };
            
            return EditVm;
        }

        public void EditGame(EditGameBindingModel bind)
        {
            Game game = this.Context.Games.Find(bind.Id);
            game.ImageThumbnail = bind.ImageThumbnail;
            game.Price = bind.Price;
            game.ReleaseDate = bind.ReleaseDate;
            game.Size = bind.Size;
            game.Title = bind.Title;
            game.Trailer = bind.Trailer;
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Game game = this.Context.Games.Find(id);
            this.Context.Games.Remove(game);
            this.Context.SaveChanges();
        }

        public DeleteViewModel GetDeleteViewModel(int id)
        {
            Game game = this.Context.Games.Find(id);
            DeleteViewModel deleteVm = new DeleteViewModel()
            {
                Id = game.Id,
                Title = game.Title               
            };
            return deleteVm;
        }

        public void AddGame(Game game)
        {
            this.Context.Games.Add(game);
            this.Context.SaveChanges();
        }
    }
}
