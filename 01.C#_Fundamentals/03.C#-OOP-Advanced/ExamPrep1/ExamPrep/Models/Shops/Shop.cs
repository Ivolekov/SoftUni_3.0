namespace ExamPrep.Models.Shops
{
    using ExamPrep.Contracts;

    public abstract class Shop : IShop
    {
        private int capacity;
        private IShop successor;

        public Shop(int capacity, IShop successor)
        {
            this.Capacity = capacity;
            this.Successor = successor;
        }

        public int Capacity { get; }

        public IShop Successor { get; }
    }
}
