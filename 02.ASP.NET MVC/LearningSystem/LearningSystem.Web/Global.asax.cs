using AutoMapper;
using LearningSystem.Models.BindingModels;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigMapper()
        {
            Mapper.Initialize(expresion=>
            {
                expresion.CreateMap<Course, DetailsCourseViewModel>();
                expresion.CreateMap<Course, CourseViewModel>();
                expresion.CreateMap<ApplicationUser, ProfileViewModel>();
                expresion.CreateMap<Course, UserCourseViewModel>();
                expresion.CreateMap<ApplicationUser, EditUsersViewModel>();
                expresion.CreateMap<Article, ArticleViewModel>();
                expresion.CreateMap<ApplicationUser, ArticleAuthorViewModel>();
                expresion.CreateMap<AddArticleBindingModel, Article>();
                expresion.CreateMap<Student, AdminPageUserViewModel>().ForMember(vm => vm.Name, config => config.MapFrom(s => s.User.Name));
            });
        }
    }
}
