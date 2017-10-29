namespace LambdaCore_Skeleton.Command
{
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Contracts;

    public class SelectCoreCommand : Command
    {
        [Inject]
        private IRepository powerPlant;

        public SelectCoreCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            this.powerPlant.SetCurrentCore(this.Data[1][0]);
            return $"Currently selected Core {this.Data[1][0]}!";
        }
    }
}
