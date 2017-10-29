namespace Lab.AdvancedCSharp.Bashsoft.IO
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Contracts;

    public class CommandInterpreter : IInterpreter
    {
        #region Private Fields

        private readonly IContentComparer tester;

        private readonly IDatabase repository;

        private readonly IDownloadManager downloadManager;

        private readonly IDirectoryManager ioManager;

        #endregion

        #region Constructors

        public CommandInterpreter(IContentComparer tester, IDatabase repository, IDownloadManager downloadManager, IDirectoryManager ioManager)
        {
            this.tester = tester;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.ioManager = ioManager;
        }

        #endregion

        #region Public Methods

        public void InterpretCommand(string input)
        {
            string[] commandArgs = input.Split();
            string commandName = commandArgs[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, commandArgs);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }
        
        #endregion

        #region Private Methods

        private IExecutable ParseCommand(string input, string commandName, string[] commandArgs)
        {
            object[] constructionParameters = new object[]
            {
                input, commandArgs
            };

            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(t => t.GetCustomAttributes(typeof(AliasAttribute))
                    .Any(atr => atr.Equals(commandName)));

            Type interpreterType = typeof(CommandInterpreter);

            Command command = (Command)Activator.CreateInstance(commandType, constructionParameters);

            FieldInfo[] commandFields = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] interpreterFields = interpreterType
                .GetFields(BindingFlags.Instance |
                BindingFlags.NonPublic);

            foreach (var commandField in commandFields)
            {
                Attribute attribute = commandField
                    .GetCustomAttribute(typeof(InjectAttribute));
                if (attribute != null)
                {
                    if (interpreterFields.Any(x => x.FieldType == commandField.FieldType))
                    {
                        var fieldValue = interpreterFields
                            .First(x => x.FieldType == commandField.FieldType).GetValue(this);

                        commandField.SetValue(command, fieldValue);
                    }
                }
            }

            return command;
        }

        #endregion
    }
}
