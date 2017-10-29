namespace Shouter
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "Shouter");
        }
    }
}
