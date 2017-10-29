namespace SoftUniGameScore.Views.User
{
    using SimpleMVC.Interfaces;
    using System.IO;
    using System.Text;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string header = File.ReadAllText(Constants.ConstantPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ConstantPath + Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.ConstantPath + Constants.Register);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(navigation);
            htmlBuilder.Append(header);
            htmlBuilder.Append(register);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
