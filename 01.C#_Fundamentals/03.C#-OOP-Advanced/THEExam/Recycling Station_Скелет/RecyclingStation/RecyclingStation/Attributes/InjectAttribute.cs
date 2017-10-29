namespace RecyclingStation.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : DisposableAttribute
    {
    }
}
