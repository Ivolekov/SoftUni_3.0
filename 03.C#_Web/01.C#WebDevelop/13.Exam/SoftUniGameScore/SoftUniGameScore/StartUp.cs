namespace SoftUniGameScore
{
    using SimpleMVC;
    using SimpleHttpServer;
    public class StartUp
    {
        public static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniGameScore");
        }
    }
}
