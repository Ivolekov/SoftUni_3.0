namespace AddPizza
{
    using PizzaMore.Data;
    using PIzzaMore.Utility;
    using System.Collections.Generic;

    public class AddPizza
    {
        private static IDictionary<string, string> RequestParameters;
        private static Header Header = new Header();
        private static Session Session = new Session();
        public static void Main()
        {
            Session = WebUtil.GetSession();
            if (Session != null)
            {
                if (WebUtil.IsGet())
                {
                    ShowPage();
                }
                else if (WebUtil.IsPost())
                {
                    CreatePizza();
                    ShowPage();
                }
            }
            else
            {
                Header.Print();
                WebUtil.PageNotAllowed();
            }
        }

        private static void CreatePizza()
        {
            RequestParameters = WebUtil.RetrivePostParameters();
            string title = RequestParameters["title"];
            string recipe = RequestParameters["recipe"];
            string url = RequestParameters["url"];
            using (var context = new PizzaMoreContext())
            {
                var user = context.Users.Find(Session.User.Id);
                Pizza pizza = new Pizza()
                {
                    DownVotes = 0,
                    UpVotes = 0,
                    ImageUrl = url,
                    Recipe = recipe,
                    Title = title,
                    Owner = user
                };
                user.Suggestions.Add(pizza);
                context.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.AddPizza);
        }
    }
}
