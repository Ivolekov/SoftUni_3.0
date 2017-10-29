namespace PizzaMore
{
    using SimpleHttpServer;
    using SimpleMVC;
    public class AppStart
    {
        public static void Main()
        {
            HttpServer server  = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMore");
        }
    }
}
