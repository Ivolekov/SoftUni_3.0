namespace SimpleMVC
{
    using System;
    using System.Reflection;
    using SimpleHttpServer;

    public static class MvcEngine
    {
        public static void Run(HttpServer server, string apllicationAssemblyName)
        {
            RegisterAssemblyName(apllicationAssemblyName);
            LoadAppAssembly(apllicationAssemblyName);
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                //Log errors
                Console.WriteLine(e.Message);
            }
        }

        private static void LoadAppAssembly(string apllicationAssemblyName)
        {
            MvcContext.Current.AplicationAssembly = Assembly.Load(apllicationAssemblyName);
        }

        private static void RegisterAssemblyName(string apllicationAssemblyName)
        {
            MvcContext.Current.AssemblyName = apllicationAssemblyName;

        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = "Controllers";
            MvcContext.Current.ControllersSuffix = "Controller";
        }

        private static void RegisterViews()
        {
            MvcContext.Current.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Current.ModelsFolder = "Models";
        }
    }
}
