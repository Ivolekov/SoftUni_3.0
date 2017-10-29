namespace ExamPrep
{
    using ExamPrep.Parser;

    class Program
    {
        static void Main(string[] args)
        {
            IParser parser = new AttributeParser();
            parser.Parse();
        }
    }
}
