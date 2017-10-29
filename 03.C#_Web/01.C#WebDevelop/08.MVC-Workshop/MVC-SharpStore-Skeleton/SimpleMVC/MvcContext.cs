namespace SimpleMVC
{
    using System.Reflection;

    public class MvcContext
    {
        public static readonly MvcContext Current = new MvcContext();
        public Assembly AplicationAssembly { get; set; }
        public string AssemblyName { get; set; }
        public string ControllersFolder { get; set; }
        public string ControllersSuffix { get; set; }
        public string ViewsFolder { get; set; }
        public string ModelsFolder { get; set; }
    }
}
