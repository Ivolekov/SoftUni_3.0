namespace IssueTrackerApp.Views.Home
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

    public class Index : IRenderable<LoginViewModel>
    {
        public LoginViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlBuilder = new StringBuilder();

            string menu = string.Empty;
            if (this.Model.Username != null)
            {
                menu = File.ReadAllText(Constants.ConstantPath + Constants.MenuLogged);
                menu = string.Format(menu, this.Model.Username);
            }
            else
            {
                menu = File.ReadAllText(Constants.ConstantPath + Constants.Menu);
            }
            string home = File.ReadAllText(Constants.ConstantPath + Constants.Home);
            string footer = File.ReadAllText(Constants.ConstantPath + Constants.Footer);

            htmlBuilder.Append(menu);
            htmlBuilder.Append(home);
            htmlBuilder.Append(footer);
            return htmlBuilder.ToString();
        }
    }
}
