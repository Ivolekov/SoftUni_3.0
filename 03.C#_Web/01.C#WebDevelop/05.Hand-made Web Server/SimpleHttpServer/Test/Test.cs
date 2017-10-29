namespace Test
{
    using SimpleHttpServer;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main()
        {
            var routes = new List<Route>()
            {
                new Route
                {
                    Name = "Hello Handler",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) =>
                    {
                        return new HttpResponse(ResponseStatusCode.OK)
                        {
                            ContentAsUTF8 = "<h3>Hello from HttpServer :)</h3>",
                        };
                    }
                }
            };

            HttpServer httpServer = new HttpServer(8081, routes);
            httpServer.Listen();
        }
    }
}
