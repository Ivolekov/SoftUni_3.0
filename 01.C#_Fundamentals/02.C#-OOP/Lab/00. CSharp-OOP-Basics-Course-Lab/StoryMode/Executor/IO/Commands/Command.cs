using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Exceptions;
using Executor.Network;

namespace Executor.IO.Commands
{
    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester tester;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager inputOutputManager;

        protected Command(string input, string[] data, Tester tester, 
            StudentsRepository repository, DownloadManager downloadManager,
            IOManager ioManager)
        {
            this.Input = input;
            this.Data = data;
            this.tester = tester;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = ioManager;
        }

        protected string Input
        {
            get { return this.input; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }

        protected string[] Data
        {
            get { return this.data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected Tester Tester
        {
            get { return this.tester; }
        }

        protected StudentsRepository Repository
        {
            get { return this.repository; }
        }

        protected DownloadManager DownloadManager
        {
            get { return this.downloadManager; }
        }

        protected IOManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }

        public void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command {input} is invalid");
        }

        public abstract void Execute();
    }
}
