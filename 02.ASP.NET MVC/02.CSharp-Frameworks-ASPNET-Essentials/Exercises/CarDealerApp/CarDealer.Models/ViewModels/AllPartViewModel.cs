namespace CarDealer.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AllPartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public string SupplierName { get; set; }

        public int Quantity { get; set; }
    }
}
