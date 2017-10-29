namespace LambdaCore_Skeleton.Factories
{
    using System;
    using LambdaCore_Skeleton.Contracts;

    public class FragmentFactory : IFragmentFactory
    {
        private const string NameSpace = "LambdaCore_Skeleton.Models.Fragments.";
        private const string Text = "BaseFragment";

        public IFragment CreateFragment(string type, string name, int pressure)
        {
            var fullName = NameSpace + type + Text;
            Type t = Type.GetType(fullName);
            object[] fragmentParams = new object[] { name, pressure };
            IFragment fragment;

            try
            {
                fragment = (IFragment)Activator.CreateInstance(t, fragmentParams);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Failed to attach Fragment {name}!");
            }
            return fragment;
        }
    }
}
