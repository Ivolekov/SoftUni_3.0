namespace ExamPrep.Models.Shops
{
    using ExamPrep.Contracts;

    class Bazaar : Shop
    {
        private const int Capacity = 30;

        public Bazaar(IShop successor)
            :base(Capacity, successor)
        {
        }
    }
}
