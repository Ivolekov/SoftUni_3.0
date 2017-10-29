namespace RecyclingStation.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using RecyclingStation.Attributes;
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandsNamespacePath = "RecyclingStation.Core.Commands.";

        private IGarbageFactory garbageFactory;
        private IGarbageProcessor garbageProcessor;
        private IProcessingData processingData;

        public CommandInterpreter(IGarbageFactory garbageFactory, IGarbageProcessor garbageProcessor, IProcessingData processingData)
        {
            this.garbageFactory = garbageFactory;
            this.garbageProcessor = garbageProcessor;
            this.processingData = processingData;
        }

        public IExecutable InterpretCommand(string commandName, string[] commandArgs)
        {
            var commandFullName = CommandsNamespacePath + commandName;
           
            Type t = Type.GetType(commandFullName);
            object[] commandParameters = new object[] { commandArgs };

            IExecutable command = null;

            try
            {
                command = (IExecutable)Activator.CreateInstance(t, commandParameters);
            }
            catch
            {
                throw new InvalidOperationException("Invalid command!!!");
            }

            command = this.InjectDependencies(command);
            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeof(CommandInterpreter)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));

                if (fieldAttribute == null)
                {
                    continue;
                }

                var firstOrDefault = fieldsOfInterpreter.FirstOrDefault(x => x.FieldType == field.FieldType);

                if (firstOrDefault != null)
                {
                    var setField = firstOrDefault
                        .GetValue(this);

                    field.SetValue(command, setField);
                }
            }

            return command;
        }
    }
}
