namespace SoftUniGameScore.Views.Game
{
    using SimpleMVC.Interfaces.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Delete : IRenderable<DeleteViewModel>
    {
        public DeleteViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavLogged);
            string deleteGame = File.ReadAllText(Constants.ConstantPath + Constants.DeleteGame);
            deleteGame = string.Format(deleteGame, Model.Title, Model.Id);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(deleteGame);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
