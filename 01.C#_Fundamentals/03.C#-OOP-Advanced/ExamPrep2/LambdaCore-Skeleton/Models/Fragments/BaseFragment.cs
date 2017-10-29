namespace LambdaCore_Skeleton.Models.Fragments
{
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Enums;

    public abstract class BaseFragment : IFragment
    {
        private string name;
        private FragmentType type;
        private int pressureAffection;

        protected BaseFragment(string name, FragmentType type, int pressureAffection)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
            this.type = type;
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public virtual int PressureAffection
        {
            get { return this.pressureAffection; }
            protected set { this.pressureAffection = value; }
        }
    }
}
