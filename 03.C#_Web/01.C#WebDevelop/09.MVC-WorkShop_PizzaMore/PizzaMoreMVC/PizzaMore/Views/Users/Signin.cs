﻿namespace PizzaMore.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Signin : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signin.html");
        }
    }
}
