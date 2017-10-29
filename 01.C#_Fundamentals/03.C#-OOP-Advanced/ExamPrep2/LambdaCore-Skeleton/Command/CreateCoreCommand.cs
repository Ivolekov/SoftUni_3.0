namespace LambdaCore_Skeleton.Command
{
    using System;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Contracts;

    public class CreateCoreCommand : Command
    {
        [Inject]
        private ICoreFactory coreFactory;

        [Inject]
        private IRepository powerPlant;

        public CreateCoreCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var coreType = this.Data[1];
            var coreDurability = int.Parse(this.Data[2]);

            ICore core = this.coreFactory.CreateCore(coreType, coreDurability);
            this.powerPlant.AddCore(core);

            return $"Successfully created Core {core.Name}!";
        }
    }
}
