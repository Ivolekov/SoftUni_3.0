namespace SoftUniGameScore.Views.Game
{
    using SimpleMVC.Interfaces.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Edit : IRenderable<EditViewModel>
    {
        public EditViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavLogged);
            string editGame = File.ReadAllText(Constants.ConstantPath + Constants.EditGame);
            editGame = string.Format(editGame, Model.Id, Model.Title, Model.Description, Model.ImageUrl, Model.Price, Model.Size, Model.Trailer);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(editGame);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
