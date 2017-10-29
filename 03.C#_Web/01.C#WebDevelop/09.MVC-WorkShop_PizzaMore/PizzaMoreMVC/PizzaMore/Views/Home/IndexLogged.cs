namespace PizzaMore.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/index-logged.html");
        }
    }
}
