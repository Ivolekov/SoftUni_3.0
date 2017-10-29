namespace PizzaMore.Controllers
{
    using System.Linq;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Security;
    using PizzaMore.ViewModel;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using BindingModels;
    using System;
    using AutoMapper;

    public class MenuController : Controller
    {
        private SignInManager signInManager;

        public MenuController()
        {
            this.signInManager = new SignInManager(new PizzaMoreMVCContext());
        }

        [HttpGet]
        public IActionResult<PizzaSuggestionViewModel> Index(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
            }

            using (PizzaMoreMVCContext context = new PizzaMoreMVCContext())
            {
                User currentUser = context.Sessions.First(s => s.SessionId == session.Id).User;
                PizzaSuggestionViewModel viewModel = new PizzaSuggestionViewModel()
                {
                    Email = currentUser.Email,
                    PizzaSuggestions = currentUser.PizzaSuggestions
                };
                return this.View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpSession session, HttpResponse response, AddPizzaBindingModel model)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/users/signin");
                return null;
            }

            using (PizzaMoreMVCContext context = new PizzaMoreMVCContext())
            {
                ConfigureMapper(session, context);
                Pizza pizzaEntity = Mapper.Map<Pizza>(model);
                context.Pizzas.Add(pizzaEntity);
                context.SaveChanges();
            }

            this.Redirect(response, "/menu/index");
            return null;
        }

        private void ConfigureMapper(HttpSession session, PizzaMoreMVCContext context)
        {
            Mapper.Initialize(e => e.CreateMap<AddPizzaBindingModel, Pizza>()
            .ForMember(p => p.Owner, config => config
              .MapFrom(u => context.Sessions.First(s => s.SessionId == session.Id).User)));
        }
    }
}
