namespace Shouter.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Register : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/registration.html");
        }
    }
}
