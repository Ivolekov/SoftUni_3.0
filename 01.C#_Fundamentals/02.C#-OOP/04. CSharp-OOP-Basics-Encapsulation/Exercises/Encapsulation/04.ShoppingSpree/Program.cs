using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _04.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                string[] personLIne = Console.ReadLine().Split(';');
                foreach (var personData in personLIne)
                {
                    int indexEqual = personData.IndexOf('=');
                    string personName = personData.Substring(0, indexEqual);
                    decimal personMoney = decimal.Parse(personData.Substring(indexEqual + 1));
                    Person person = new Person(personName, personMoney);
                    persons.Add(person);

                }
                string[] productLine = Console.ReadLine().Split(';');
                foreach (var productData in productLine)
                {
                    int indexEqual = productData.IndexOf('=');
                    string productName = productData.Substring(0, indexEqual);
                    decimal productCost = decimal.Parse(productData.Substring(indexEqual + 1));
                    Product product = new Product(productName, productCost);
                    products.Add(productName, product);
                }
            }
            catch (Exception ex)
            {

                Console.Write("");
            }


            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split(' ');
                try
                {
                    string personName = inputArgs[0];
                    string productName = inputArgs[1];
                    foreach (Person person in persons)
                    {
                        if (person.Name.Equals(personName))
                        {
                            person.AddProduct(products);
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("");
                }
               

                input = Console.ReadLine();
            }
        }
    }

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }


        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (this.money < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }


        public void AddProduct(Product product)
        {
            if (product.Cost > this.money)
            {
                CannotBuyMessage(product);
            }

            this.money -= product.Cost;
            BuyMessage(product);
            products.Add(product);
        }

        private void CannotBuyMessage(Product product)
        {
            Console.WriteLine($"{nameof(this.Name)} can't afford {nameof(product.Name)}");
        }

        private void BuyMessage(Product product)
        {
            Console.WriteLine($"{nameof(this.Name)} bought  {nameof(product.Name)}");
        }
    }

    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public decimal Cost
        {
            get { return this.cost; }
            set
            {
                if (this.cost<0)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }
                this.cost = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
    }
}
