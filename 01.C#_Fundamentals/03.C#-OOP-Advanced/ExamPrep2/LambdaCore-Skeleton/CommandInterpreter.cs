namespace LambdaCore_Skeleton
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Contracts;

    public class CommandInterpreter
    {
        private const string NameSpacePath = "LambdaCore_Skeleton.Command.";
        private const string CommandText = "Command";

        ICoreFactory coreFactory;
        IFragmentFactory fragmentFactory;
        IRepository powerPlant;

        public CommandInterpreter(ICoreFactory coreFactory, 
            IFragmentFactory fragmentFactory, IRepository poweRepository)
        {
            this.coreFactory = coreFactory;
            this.fragmentFactory = fragmentFactory;
            this.powerPlant = poweRepository;
        }

        public IExecutable InterpretCommaned(string commandName, string[] commandArgs)
        {
            var commandFullName = NameSpacePath + commandName + CommandText;

            Type t = Type.GetType(commandFullName);
            object[] commandParams = new object[] { commandArgs };
            IExecutable command = null;

            try
            {
                command = (IExecutable)Activator.CreateInstance(t, commandParams);

            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command!!!");
            }
            command = this.InjectDepend(command);
            return command;
        }

        private IExecutable InjectDepend(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldOfInterpreter = typeof(CommandInterpreter)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));

                if (fieldAttribute == null)
                {
                    continue;
                }

                var firstOrDefault = fieldOfInterpreter
                    .FirstOrDefault(x => x.FieldType == field.FieldType);

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
