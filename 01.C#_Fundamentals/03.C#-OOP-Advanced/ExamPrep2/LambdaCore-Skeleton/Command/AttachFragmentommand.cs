namespace LambdaCore_Skeleton.Command
{
    using System;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Factories;
    using LambdaCore_Skeleton.Repository;

    public class AttachFragmentommand : Command
    {
        [Inject]
        private IFragmentFactory fragmentFactory;

        [Inject]
        private IRepository powerPlant;

        public AttachFragmentommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            if (!this.powerPlant.IsCurrentCoreSet())
            {
                throw new InvalidOperationException($"Failed to attach Fragment {this.Data[2]}!");
            }

            var fragmentType = this.Data[1];
            var fragmentName = this.Data[2];
            var fragmentPressure = int.Parse(this.Data[3]);

            IFragment fragment = this.fragmentFactory.CreateFragment(fragmentType, fragmentName, fragmentPressure);

            this.powerPlant.AddFragment(fragment);

            return $"Successfully attached Fragment {this.Data[2]} to Core {this.powerPlant.CurrentCoreName()}!";
        }
    }
}
