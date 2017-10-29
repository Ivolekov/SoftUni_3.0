namespace ExamPrep.Models.Products
{
    class SmallProduct : Product
    {
        public SmallProduct(string name, int size)
            : base(name, size)
        {
        }

        public override int Size
        {
            get { return base.Size; }
            set { base.Size = value / 2; }
        }
    }
}
