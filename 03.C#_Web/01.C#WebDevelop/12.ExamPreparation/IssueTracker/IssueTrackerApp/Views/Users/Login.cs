namespace IssueTrackerApp.Views.Users
{
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System.IO;
    using System.Text;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    public class Login : IRenderable<HashSet<RegistrationVerificationErrorViewModel>>
    {
        public HashSet<RegistrationVerificationErrorViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();

            string menu = File.ReadAllText(Constants.ConstantPath +  Constants.Menu);

            StringBuilder errorBuilder = new StringBuilder();
            foreach (var item in Model)
            {
                errorBuilder.Append(item.ToString());
            }

            string login = File.ReadAllText(Constants.ConstantPath + Constants.Login);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(menu);
            htmlBuilder.Append(errorBuilder);
            htmlBuilder.Append(login);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
