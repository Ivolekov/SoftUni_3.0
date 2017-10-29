namespace IssueTrackerApp.Views.Users
{
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class Register : IRenderable<HashSet<RegistrationVerificationErrorViewModel>>
    {
        public HashSet<RegistrationVerificationErrorViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string menu = File.ReadAllText(Constants.ConstantPath + Constants.Menu);

            StringBuilder errorBuilder = new StringBuilder();
            foreach (var item in Model)
            {
                errorBuilder.Append(item.ToString());
            }

            string register = File.ReadAllText(Constants.ConstantPath + Constants.Register);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);
            htmlBuilder.Append(menu);
            htmlBuilder.Append(errorBuilder);
            htmlBuilder.Append(register);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
