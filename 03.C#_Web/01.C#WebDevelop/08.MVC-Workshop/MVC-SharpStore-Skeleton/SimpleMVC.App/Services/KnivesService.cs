namespace SimpleMVC.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SimpleMVC.App.Data;
    using SimpleMVC.App.Models;
    using SimpleMVC.App.ViewModels;

    public class KnivesService : Service
    {
        public KnivesService(SharpStoreContext context) : base(context)
        {
        }

        public IEnumerable<ProductsViewModel> GetProducts(string productName)
        {
            var knives = this.context.Knives.Where(k=>k.Name.Contains(productName)).ToArray();
            List<ProductsViewModel> viewModel = new List<ProductsViewModel>();
            foreach (Knive knife in knives)
            {
                viewModel.Add(new ProductsViewModel()
                {
                    Id = knife.Id,
                    Name = knife.Name,
                    Price = knife.Price,
                    ImageUrl = knife.ImageUrl
                });

            }
            return viewModel;
        }

        //public IEnumerable<ProductsViewModel> GetAllKnives()
        //{
        //    List<ProductsViewModel> knivesVMs = new List<ProductsViewModel>();
        //    using (var context = new SharpStoreContext())
        //    {
        //        foreach (var knife in context.Knives)
        //        {
        //            knivesVMs.Add(new ProductsViewModel
        //            {
        //                ImageUrl = knife.ImageUrl,
        //                Name = knife.Name,
        //                Price = knife.Price
        //            });
        //        }
        //    }
        //    return knivesVMs;
        //}
    }
}
