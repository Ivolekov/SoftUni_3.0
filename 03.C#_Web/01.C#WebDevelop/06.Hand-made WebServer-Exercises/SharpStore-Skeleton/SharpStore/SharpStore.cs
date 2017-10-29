using SharpStore.Data;
using SimpleHttpServer;
using SimpleHttpServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SharpStore.Data.Models;
using System;
using System.Net;

namespace SharpStore
{
    class SharpStore
    {
        static void Main(string[] args)
        {
            SharpStoreContext context = new SharpStoreContext();

            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/home.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap CSS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "About Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/about$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/about.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "About Pictures",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/images/.+$",
                    Callable = (request) =>
                    {
                        var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };
                    }
                },
                new Route()
                {
                    Name = "Products Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/products$",
                    Callable = (request) =>
                    {
                        var knives = context.Knives.ToList();
                        var products = GenerateProducts(knives);

                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = products
                        };
                    }
                },
                new Route()
                {
                    Name = "Products Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.POST,
                    UrlRegex = "^/products$",
                    Callable = (request) =>
                    {
                        string filter = request.Content.Split('=')[1];
                        var knives = context.Knives.Where(k=>k.Name.Contains(filter)).ToList();
                        var products = GenerateProducts(knives);

                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = products
                        };
                    }
                },

                new Route()
                {
                    Name = "Contants Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/contacts$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/contact.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Contants Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.POST,
                    UrlRegex = "^/contacts$",
                    Callable = (request) =>
                    {
                        UploadMessageInDB(request, context);
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/contact.html")
                        };
                    }
                }
            };

            HttpServer httpServer = new HttpServer(8081, routes);
            httpServer.Listen();
        }

        private static void UploadMessageInDB(HttpRequest request, SharpStoreContext context)
        {
            string requestContent = WebUtility.UrlDecode(request.Content);
            string[] parameters = requestContent.Split('&');
            Dictionary<string, string> nameValuePair = new Dictionary<string, string>();
            foreach (var parameter in parameters)
            {
                string[] parameterInfo = parameter.Split('=');
                nameValuePair.Add(parameterInfo[0], parameterInfo[1]);
            }
            Message message = new Message()
            {
                Sender = nameValuePair["emailAddress"],
                Subject = nameValuePair["subject"],
                FullMessage = nameValuePair["message"]
            };
            context.Messages.Add(message);
            context.SaveChanges();
        }

        private static string GenerateProducts(List<Knife> knives)
        {
            int count = 0;
            string htmlProductsMiddle = string.Empty;
            foreach (var knife in knives)
            {
                if (count % 3 == 0)
                {
                    htmlProductsMiddle += "<div class=\"row\">";
                }

                htmlProductsMiddle +=
                     $"<div class=\"img-thumbnail\" style=\"margin:10px; padding: 10px\">\r\n                    <img src=\"{knife.ImageUrl}\" alt=\"Card image cap\" width=\"300\" height=\"150\">\r\n                    <div class=\"card-block\">\r\n                        <h3 class=\"card-title\">{knife.Name}</h3>\r\n                        <p class=\"card-text\">${knife.Price}</p>\r\n                        <button class=\"btn btn-primary\" style=\"margin-bottom: 10px\" type=\"submit\">Buy Now</button>\r\n                    </div>\r\n                </div>";

                if (count % 3 == 2)
                {
                    htmlProductsMiddle += "</div>";
                }
                count++;
            }
            string finalHtml = File.ReadAllText("../../content/products-top.html");
            finalHtml += htmlProductsMiddle;
            finalHtml += File.ReadAllText("../../content/products-bottom.html");
            return finalHtml;
        }
    }
}