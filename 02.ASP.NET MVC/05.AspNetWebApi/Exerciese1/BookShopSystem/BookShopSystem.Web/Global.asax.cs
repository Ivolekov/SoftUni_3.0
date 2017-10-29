using AutoMapper;
using BookShopSytem.Models.BindingModels;
using BookShopSytem.Models.BindingModels.Books;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.Entities;
using BookShopSytem.Models.ViewModels;
using BookShopSytem.Models.ViewModels.Authors;
using BookShopSytem.Models.ViewModels.Books;
using BookShopSytem.Models.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookShopSystem.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigMapper()
        {
            Mapper.Initialize(expresion =>
            {
                expresion.CreateMap<Author, DetailedAuthorVm>()
                .ForMember(vm=>vm.BookTitles, configurationExpression => 
                configurationExpression.MapFrom(author=>author.Books.Select(b=>b.Title)));

                expresion.CreateMap<AddAuthorBm, Author>();

                expresion.CreateMap<Book, BookAuthorVm>()
                .ForMember(vm => vm.CategoryNames, configurationExpression =>
                 configurationExpression.MapFrom(book => book.Categories.Select(b => b.Name)));

                expresion.CreateMap<Book, DetailedBookVm>()
                .ForMember(vm => vm.CategoryNames, configerExpresion =>
                  configerExpresion.MapFrom(b => b.Categories.Select(c => c.Name)))
                  .ForMember(vm=>vm.AuthorName, configerExpresion=>
                  configerExpresion.MapFrom(a=>a.Author.FirstName))
                  .ForMember(vm => vm.AuthorId, configerExpresion =>
                    configerExpresion.MapFrom(a => a.Author.Id));

                expresion.CreateMap<AddBookBm, Book>();

                expresion.CreateMap<Category, CategoryVm>();

                expresion.CreateMap<AddCategoryBm, Category>();

                expresion.CreateMap<Book, SearchBookVm>();

                //expresion.CreateMap<EditBookBm, Book>()
                //.ForMember(book => book.ReleaseDate, configExpr => configExpr
                //.MapFrom(vm => DateTime.ParseExact(vm.ReleaseDate, "dd-mm-yyyy", null)));
            });
        }
    }
}
