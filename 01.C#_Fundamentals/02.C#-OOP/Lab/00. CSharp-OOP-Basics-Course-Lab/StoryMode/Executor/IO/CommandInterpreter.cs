using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Executor.Exceptions;
using Executor.IO.Commands;
using Executor.Network;

namespace Executor
{
    public class CommandInterpreter
    {
        private Tester judje;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager inputOutputIoManager;

        public CommandInterpreter(Tester judje, StudentsRepository repository,
            DownloadManager downloadManager, IOManager inputOutputIoManager)
        {
            this.judje = judje;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputIoManager = inputOutputIoManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }


        }

        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "show":
                    return new ShowCourseCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "open":
                    return new OpenFileCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judje, this.repository,
                       this.downloadManager, this.inputOutputIoManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judje, this.repository,
                       this.downloadManager, this.inputOutputIoManager);
                case "download":
                    return new DownloadFileCommand(input, data, this.judje, this.repository,
                       this.downloadManager, this.inputOutputIoManager);
                case "downloadasynch":
                    return new DownloadAsynchCommand(input, data, this.judje, this.repository,
                       this.downloadManager, this.inputOutputIoManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judje, this.repository,
                        this.downloadManager, this.inputOutputIoManager);
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
