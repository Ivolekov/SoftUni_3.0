using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Executor.Attributes;
using Executor.Exceptions;
using Executor.IO.Commands;
using Executor.Network;
using Executor.Judge;
using Executor.Repository;
using Executor.Contracts;
using Executor.IO.Contracts;
using Executor.Judge.Contracts;
using Executor.Repository.Contacts;
using Executor.Network.Contract;

namespace Executor.IO
{
    using Executor.Contracts.Repository;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDownloadManager downloadManager;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository,
            IDownloadManager downloadManager, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(String input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] paremetarForConstructor = new object[]
            {
                input, data
            };

            Type typeOfCommand =
                Assembly.GetExecutingAssembly().GetTypes()
                    .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                        .Where(atr => atr.Equals(command))
                        .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, paremetarForConstructor);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe,
                            fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }

}
