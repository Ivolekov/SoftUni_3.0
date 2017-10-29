namespace PaymentSystem.Models
{
    public abstract class BillingDetail
    {
        public int ID { get; set; }

        public int Number { get; set; }

        public string Owner { get; set; }
    }
}