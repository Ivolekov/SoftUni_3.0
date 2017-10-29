using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.Data;
using System.IO;

namespace PIzzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            var enviromentVariable = Environment.GetEnvironmentVariable(Constants.RequestMethod);
            if (enviromentVariable != null)
            {
                string requestMethod = enviromentVariable.ToLower();
                if (requestMethod == "post")
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsGet()
        {
            var enviromentVariable = Environment.GetEnvironmentVariable(Constants.RequestMethod);
            if (enviromentVariable != null)
            {
                string requestMethod = enviromentVariable.ToLower();
                if (requestMethod == "get")
                {
                    return true;
                }
            }
            return false;
        }

        public static IDictionary<string, string> RetriveGetParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.QueryString));
            return RetriveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrivePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Console.ReadLine());
            return RetriveRequestParameters(parametersString);
        }

        private static IDictionary<string, string> RetriveRequestParameters(string parametersString)
        {
            var resultParameters = new Dictionary<string, string>();

            var parameters = parametersString.Split('&');
            foreach (var param in parameters)
            {
                var pair = param.Split('=');
                var name = pair[0];
                string value = null;
                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(name, value);
            }

            return resultParameters;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = Environment.GetEnvironmentVariable(Constants.CookiesString);
            if (string.IsNullOrEmpty(cookieString))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();
            string[] cookieSaves = cookieString.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                string[] cookiePair = cookieString.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }
            return cookies;
        }

        public static Session GetSession()
        {
            var cookies = GetCookies();
            if (!cookies.ContainsCookie(Constants.SessionId))
            {
                return null;
            }
            var sessionCookie = cookies[Constants.SessionId];
            var ctx = new PizzaMoreContext();

            var session = ctx.Sessions
                .FirstOrDefault(s => s.Id == sessionCookie.Value);
            return session;
        }

        public static void PrintFileContent(string path)
        {
            string content = File.ReadAllText(path);
            Console.WriteLine(content);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent("../../htdocs/pm/game/index.html");
        }
    }
}
