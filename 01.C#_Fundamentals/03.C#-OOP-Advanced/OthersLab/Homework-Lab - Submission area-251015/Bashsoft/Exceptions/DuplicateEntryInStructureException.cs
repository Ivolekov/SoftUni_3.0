namespace Lab.AdvancedCSharp.Bashsoft.Exceptions
{
    using System;

    public class DuplicateEntryInStructureException : Exception
    {
        private const string DuplicateEntry = "The {0} is already exists in {1}";

        public DuplicateEntryInStructureException(string message) : base(message)
        {
        }

        public DuplicateEntryInStructureException(string entry, string structure) 
            : base(string.Format(DuplicateEntry, entry, structure))
        {
        }
    }
}
