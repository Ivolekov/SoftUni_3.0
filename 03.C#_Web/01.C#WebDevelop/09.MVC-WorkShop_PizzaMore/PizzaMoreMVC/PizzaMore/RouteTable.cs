namespace PizzaMore
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.Routers;

    public static class RouteTable
    {
        public static IEnumerable<Route> Routes => new Route[]
        {
            new Route()
                    {
                        Name = "Bootstrap Map",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/css/bootstrap.min.css.map$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css.map")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
            new Route()
                    {
                        Name = "Carousel CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/content/css/carousel.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
             new Route()
                    {
                       Name = "Bootstrap JS",
                                Method = RequestMethod.GET,
                                UrlRegex = "/bootstrap/js/bootstrap.min.js$",
                                Callable = (request) =>
                                {
                                    var response = new HttpResponse()
                                    {
                                        StatusCode = ResponseStatusCode.Ok,
                                        ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                                    };
                                    response.Header.ContentType = "application/x-javascript";
                                    return response;
                                }
                    },
              new Route()
                    {
                       Name = "JQuery JS",
                                Method = RequestMethod.GET,
                                UrlRegex = "/jquery/jquery-3.1.1.js$",
                                Callable = (request) =>
                                {
                                    var response = new HttpResponse()
                                    {
                                        StatusCode = ResponseStatusCode.Ok,
                                        ContentAsUTF8 = File.ReadAllText("../../content/jquery/jquery-3.1.1.js")
                                    };
                                    response.Header.ContentType = "application/x-javascript";
                                    return response;
                                }
                    },
             new Route()
                    {
                        Name = "Bootstrap CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/css/bootstrap.min.css$",
                        Callable = (request)=>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
             new Route()
                    {
                        Name = "Pizza Pictures",
                        Method = RequestMethod.GET,
                        UrlRegex = "^/images/.+$",
                        Callable = (request)=>
                        {
                            var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/')+1);
                            return new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content = File.ReadAllBytes($"../../content/images/{nameOfFile}")
                            };
                        }
                    },
             new Route()
                    {
                        Name = "Custom CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/.+$",
                        Callable = (request)=>
                        {
                            var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/')+1);
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../content/css/{nameOfFile}")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
            new Route()
            {
                Name = "Controller/Action/GET",
                Method = RequestMethod.GET,
                UrlRegex = @"^/(.+)/(.+)$",
                Callable = new ControllerRouter().Handle
            },
            new Route()
            {
                Name = "Controller/Action/POST",
                Method = RequestMethod.POST,
                UrlRegex = @"^/(.+)/(.+)$",
                Callable = new ControllerRouter().Handle
            }
        };
    }
}
