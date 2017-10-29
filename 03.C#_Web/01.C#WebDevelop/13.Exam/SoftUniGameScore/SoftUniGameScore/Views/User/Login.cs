namespace SoftUniGameScore.Views.User
{
    using SimpleMVC.Interfaces;
    using System.IO;
    using System.Text;
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavNotLogged);
            string login = File.ReadAllText(Constants.ConstantPath + Constants.Login);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(login);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
