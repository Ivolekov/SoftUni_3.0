using System.IO;

namespace SimpleMVC.App.Views.Home
{
    using SimpleMVC.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}
