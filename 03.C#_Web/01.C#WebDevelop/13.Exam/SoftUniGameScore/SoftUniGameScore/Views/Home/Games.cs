namespace SoftUniGameScore.Views.Home
{
    using SimpleHttpServer.Models;
    using SimpleMVC.Interfaces.Generic;
    using System.IO;
    using System.Text;
    using Utilities;
    using ViewModels;

    public class Games : IRenderable<AllViewModel>
    {
        public AllViewModel Model { get; set; }
        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavLogged);
            string home = File.ReadAllText(Constants.ConstantPath + Constants.Home);

            home = string.Format(home, Model);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(home);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
