namespace Home
{
    using PizzaMore.Data;
    using PIzzaMore.Utility;
    using System.Collections.Generic;
    internal class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;

        static void Main()
        {
            AddDefaultLanguageCookie();

            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetriveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrivePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }

            ShowPage();
        }

        private static void TryLogOut()
        {
            if (RequestParameters.ContainsKey("logout"))
            {
                if (RequestParameters["logout"] == "true")
                {
                    Session = WebUtil.GetSession();
                    using (var context = new PizzaMoreContext())
                    {
                        var ses = context.Sessions.Find(Session.Id);
                        context.Sessions.Remove(ses);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsCookie("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            if (Language.Equals("BG"))
            {
                ServeHtmlBg();
            }
            else
            {
                ServeHtmlEn();
            }
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent("../../htdocs/pm/home.html");
        }

        private static void ServeHtmlBg()
        {
            WebUtil.PrintFileContent("../../htdocs/pm/home-bg.html");
        }
    }
}
