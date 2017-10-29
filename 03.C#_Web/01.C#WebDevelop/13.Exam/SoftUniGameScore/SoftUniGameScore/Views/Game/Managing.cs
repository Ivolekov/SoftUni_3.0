namespace SoftUniGameScore.Views.Game
{
    using SimpleMVC.Interfaces.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Managing : IRenderable<AllAdminGameViewModel>
    {
        public AllAdminGameViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavLogged);
            string adminGame = File.ReadAllText(Constants.ConstantPath + Constants.AdminGames);
            adminGame = string.Format(adminGame, Model);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(adminGame);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
