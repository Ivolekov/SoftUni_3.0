namespace Lab.AdvancedCSharp.Bashsoft
{
    using Contracts;
    using IO;
    using Judge;
    using Network;
    using Repository;

    public class Startup
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDatabase repository = new StudentRepository(new RepositorySorter(), new RepositoryFilter());
            IDownloadManager downloadManager = new DownloadManager();
            IDirectoryManager ioManager = new IOManager();

            IInterpreter commandInterpreter = new CommandInterpreter(tester, repository, downloadManager, ioManager);
            IReader reader = new InputReader(commandInterpreter);

            reader.StartReadingCommands();
        }
    }
}
