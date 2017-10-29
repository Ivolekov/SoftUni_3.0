 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.OfficeStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var companies = new List<Company>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Trim('|').Split(' ');
                string company = input[0];
                string product = input[4];
                int amount = int.Parse(input[2]);

                companies.Add(new Company(company, product, amount));
            }

            var sortedCompany = companies
                .OrderBy(c => c.CompanyName)
                .GroupBy(c => c.CompanyName);

            foreach (var company in sortedCompany)
            {
                var sortedProducts = company.GroupBy(p => p.Product);

                Console.Write($"{company.Key}: ");

                var productsList = new List<string>();

                foreach (var product in sortedProducts)
                {
                    int coutAmount = 0;
                    foreach (var amount in product)
                    {
                        coutAmount += amount.Amount;
                    }
                    productsList.Add($"{product.Key}-{coutAmount}");
                }
                Console.WriteLine(string.Join(", ", productsList));
            }

        }
    }

    public class Company
    {
        public Company(string companyName, string product, int amount)
        {
            this.CompanyName = companyName;
            this.Product = product;
            this.Amount = amount;
        }

        public int Amount { get; set; }
        public string CompanyName { get; set; }
        public string Product { get; set; }

        public override string ToString()
        {
            return $"{Product}-{Amount}";
        }
    }
}
