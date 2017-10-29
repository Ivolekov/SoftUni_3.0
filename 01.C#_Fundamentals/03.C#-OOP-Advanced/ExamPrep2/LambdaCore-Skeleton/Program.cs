namespace LambdaCore_Skeleton
{
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Factories;
    using LambdaCore_Skeleton.Repository;

    public class Program
    {
        public static void Main()
        {
            ICoreFactory coreFactory = new CoreFactory();
            IFragmentFactory fragment = new FragmentFactory();
            IRepository powerPlantRepository = new PowerPlantRepository();
            CommandInterpreter commandInterpreter = new CommandInterpreter(coreFactory, fragment, powerPlantRepository);
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
