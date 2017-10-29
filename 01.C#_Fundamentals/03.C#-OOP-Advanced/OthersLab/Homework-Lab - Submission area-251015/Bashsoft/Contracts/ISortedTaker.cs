namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    public interface ISortedTaker
    {
        void OrderAndTake(string courseName, string comparison, int? studentsToTake = null);
    }
}