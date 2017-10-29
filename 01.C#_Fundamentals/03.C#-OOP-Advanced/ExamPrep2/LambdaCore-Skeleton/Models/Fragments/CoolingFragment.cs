namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Enums;

    class CoolingFragment : BaseFragment
    {
        private const FragmentType Type = FragmentType.Cooling;
        private const int PresureRatio = 3;

        public CoolingFragment(string name, int pressureAffection)
            : base(name, Type, pressureAffection)
        {
        }

        public override int PressureAffection
        {
            get
            {
                return base.PressureAffection;
            }

            protected set
            {
                base.PressureAffection = value * PresureRatio;
            }
        }
    }
}
