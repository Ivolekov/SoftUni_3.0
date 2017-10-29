namespace SoftUniGameScore.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utilities;
    using ViewModels;

    public class GameController : Controller
    {
        private GameService service;

        public GameController()
        {
            this.service = new GameService();
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Info(HttpSession session, HttpResponse response, int id)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            GameDetailsViewModel model = this.service.GetGameDetailsViewModel(id);
            return this.View(model);
        }

        [HttpPost]
        public void Info(HttpSession session, HttpResponse response, GameDetailsViewModel model)
        {
            User user = AuthenticatedManager.GetAuthenticatedUser(session.Id);

            if (user == null)
            {
                this.Redirect(response, "/home/games");
                return; ;
            }
            this.service.GetGameFromViewModel(model);
        }

        [HttpGet]
        public IActionResult<AllAdminGameViewModel> Managing(HttpSession session, HttpResponse response)
        {
            if (!AuthenticatedManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/home/games");
                return null;
            }
            var model = this.service.GetAllAdminViewModel();
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Add(HttpResponse response, HttpSession session)
        {
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/user/login");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpResponse response, HttpSession session, AddGameBindingModel bind)
        {
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/user/login");
            }
            //validations for adding a game
            if (!this.service.IsAddGameViewModelValid(bind))
            {
                this.Redirect(response, "/game/add");
                return null;
            }
            //add game to database
            Game game = this.service.GetGameFromAddGameBind(bind);
            this.service.AddGame(game);
            this.Redirect(response, "/game/managing");
            return this.View();
        }

        [HttpGet]
        public IActionResult<EditViewModel> Edit(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/user/login");
            }

            EditViewModel model = this.service.GetEditViewModel(id);
            return this.View(model);
        }

        [HttpPost]
        public void Edit(HttpResponse response, HttpSession session, EditGameBindingModel bind)
        {
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/user/login");
            }

            this.service.EditGame(bind);
            this.Redirect(response, "/game/managing");
        }

        [HttpGet]
        public IActionResult<DeleteViewModel> Delete(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/user/login");
            }

            DeleteViewModel model = this.service.GetDeleteViewModel(id);
            return this.View(model);
        }

        [HttpPost]
        public void Delete(HttpResponse response, HttpSession session, DeleteViewModel bind)
        {
            if (!AuthenticatedManager.IsAdmin(session.Id))
            {
                this.Redirect(response, "/user/login");
            }

            this.service.Delete(bind.Id);
            this.Redirect(response, "/game/managing");
        }
    }
}
