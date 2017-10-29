namespace Lab.AdvancedCSharp.Bashsoft.StaticData
{
    using System.IO;

    public static class SessionData
    {
        static SessionData()
        {
            CurrentPath = Directory.GetCurrentDirectory();
        }

        public static string CurrentPath { get; set; }
    }
}
