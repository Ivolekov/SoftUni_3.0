namespace ExamPrep.Models.Products
{
    class BigProduct : Product
    {
        public BigProduct(string name, int size)
            : base(name, size)
        {
        }

        public override int Size
        {
            get { return base.Size; }
            set { base.Size = value * 2; }
        }
    }
}
