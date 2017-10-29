using SimpleHttpServer;

namespace SimpleMVC.App
{
    using SimpleMVC.App.Data;

    class AppStart
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SimpleMVC.App");
        }
    }
}
