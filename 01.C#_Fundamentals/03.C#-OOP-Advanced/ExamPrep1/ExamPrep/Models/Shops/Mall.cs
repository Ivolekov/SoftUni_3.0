namespace ExamPrep.Models.Shops
{
    using ExamPrep.Contracts;

    class Mall : Shop
    {
        private const int Capacity = int.MaxValue;

        public Mall(IShop successor)
            : base(Capacity, successor)
        {
        }
    }
}
