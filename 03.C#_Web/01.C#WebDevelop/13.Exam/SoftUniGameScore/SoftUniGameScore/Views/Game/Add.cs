namespace SoftUniGameScore.Views.Game
{
    using SimpleMVC.Interfaces;
    using System.IO;
    using System.Text;
    public class Add : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavLogged);
            string addGame = File.ReadAllText(Constants.ConstantPath + Constants.AddGame);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(addGame);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
