namespace ExamPrep.Models.Products
{
    using ExamPrep.Contracts;

    public abstract class Product : IProduct
    {
        private string name;
        private int size;

        protected Product(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; private set; }

        public virtual int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}
