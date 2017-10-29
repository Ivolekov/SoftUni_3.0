namespace SimpleMVC.App.Views.Home
{
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using SimpleMVC.App.ViewModels;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class Products : IRenderable<IEnumerable<ProductsViewModel>>
    {
        public IEnumerable<ProductsViewModel> Model { get; set; }

        public string Render()
        {
            string template = File.ReadAllText("../../content/products.html");
            StringBuilder sb = new StringBuilder();
            foreach (var viewModel in this.Model)
            {
                sb.Append(viewModel);
            }
            return string.Format(template, sb);
        }
        // public IEnumerable<ProductsViewModel> Model { get; set; }

        //public string Render()
        //{
        //    StringBuilder replacement = new StringBuilder();
        //    foreach (var knife in this.Model)
        //    {
        //        replacement.AppendLine(knife.ToString());
        //    }
        //    string originalHtml = File.ReadAllText("../../content/products.html");
        //    return string.Format(originalHtml, replacement);
        //}
    }
}
