using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Product
    {
        private ICollection<Sale> saleOfProducts;

        public Product()
        {
            this.saleOfProducts = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Sale> SalesOfProducts
        {
            get { return this.saleOfProducts; }
            set { this.saleOfProducts = value; }
        }
    }
}
