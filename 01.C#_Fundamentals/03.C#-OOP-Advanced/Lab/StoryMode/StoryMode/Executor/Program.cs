namespace Executor
{
    using Executor.Contracts.Repository;
    using Executor.IO;
    using Executor.IO.Contracts;
    using Executor.Judge;
    using Executor.Judge.Contracts;
    using Executor.Network;
    using Executor.Network.Contract;
    using Executor.Repository;
    using Executor.Repository.Contacts;

    public class Program
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDownloadManager downloadManager = new DownloadManager();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositorySorter(), new RepositioryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, downloadManager, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}