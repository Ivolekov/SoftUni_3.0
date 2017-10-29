namespace ExamPrep.Models.Shops
{
    using ExamPrep.Contracts;

    class Store : Shop
    {
        private const int Capacity = 15;

        public Store(IShop successor) 
            : base(Capacity, successor)
        {
        }
    }
}
