namespace SoftUniGameScore.Views.Game
{
    using SimpleMVC.Interfaces.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Info : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavLogged);
            string gameDetails = File.ReadAllText(Constants.ConstantPath + Constants.GameDetails);
            gameDetails = string.Format(gameDetails, Model);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(gameDetails);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
