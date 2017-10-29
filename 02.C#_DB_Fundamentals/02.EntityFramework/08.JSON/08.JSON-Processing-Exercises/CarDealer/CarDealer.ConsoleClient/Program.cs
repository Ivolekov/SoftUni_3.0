using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //SeedData();
            //1
            //OrderedCustomers();
            //2
            //CarsFromMakeToyota();
            //3
            //LocalSuppliers();
            //4
            //CarsWithTheirListOfParts();
            //5
            //TotalSalesByCustomer();
            //6
            //SalesWithAppliedDiscount();
        }

        private static void SalesWithAppliedDiscount()
        {
            CarDealerContext context = new CarDealerContext();
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    s.Discount,
                    price = s.Car.Parts.Sum(p => p.Price),
                    priceWithDiscount = (double)s.Car.Parts.Sum(p => p.Price) * (1 - s.Discount)
                });
            SeriliazedObjects(sales, "../../../results/sales-discount.json");
        }

        private static void TotalSalesByCustomer()
        {
            CarDealerContext context = new CarDealerContext();
            var customers = context.Customers
                .Where(c => c.Sales.Count() != 0)
                .OrderByDescending(c => c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price)))
                .ThenByDescending(c => c.Sales.Count)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                });
            SeriliazedObjects(customers, "../../../results/customers-total-sales.json");
        }

        private static void CarsWithTheirListOfParts()
        {
            CarDealerContext context = new CarDealerContext();
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.Parts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                });
            SeriliazedObjects(cars, "../../../results/car-and-parts.json");
        }

        private static void LocalSuppliers()
        {
            CarDealerContext context = new CarDealerContext();
            var suplliers = context.Suplliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    partsCount = s.Parts.Count
                });
            SeriliazedObjects(suplliers, "../../../results/local-supllier.json");
        }

        private static void CarsFromMakeToyota()
        {
            CarDealerContext context = new CarDealerContext();
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(m => m.Make)
                .ThenByDescending(d => d.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                });
            SeriliazedObjects(cars, "../../../results/toyota-cars.json");
        }

        private static void OrderedCustomers()
        {
            CarDealerContext context = new CarDealerContext();
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    BirthDate = c.BirthDate,
                    c.IsYoungDriver,
                    Sales = "[]"
                });
            SeriliazedObjects(customers, "../../../results/ordered-customers.json");
        }

        private static void SeriliazedObjects<T>(T entity, string path)
        {
            string json = JsonConvert.SerializeObject(entity, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private static void SeedData()
        {
            SeedSuplliers();
            SeedParts();
            SeedCars();
            SeedCustomers();
            SeedSales();
        }

        private static void SeedSales()
        {
            CarDealerContext context = new CarDealerContext();
            Random rnd = new Random();
            List<double> rates = new List<double> { 0, 0.05, 0.1, 0.15, 0.2, 0.3, 0.4, 0.5 };

            foreach (var car in context.Cars)
            {
                int rndCustomerId = rnd.Next(1, context.Customers.Count() + 1);
                Customer customeToAdd = context.Customers.FirstOrDefault(c => c.Id == rndCustomerId);

                double rate = rates[rnd.Next(0, rates.Count())];
                if (customeToAdd.IsYoungDriver)
                {
                    rate += 0.5;
                }

                context.Sales.Add(new Sale
                {
                    Car = car,
                    Customer = customeToAdd,
                    Discount = rate
                });
            }
            context.SaveChanges();
        }

        private static void SeedCustomers()
        {
            CarDealerContext context = new CarDealerContext();
            string customersJson = File.ReadAllText("../../../datasets/customers.json");
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(customersJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void SeedCars()
        {
            CarDealerContext context = new CarDealerContext();
            string carsJson = File.ReadAllText("../../../datasets/cars.json");
            IEnumerable<Car> cars = JsonConvert.DeserializeObject<IEnumerable<Car>>(carsJson);
            Random rnd = new Random();

            foreach (var car in cars)
            {
                int rndNumber = rnd.Next(10, 21);

                for (int i = 0; i < rndNumber; i++)
                {
                    int partIndex = rnd.Next(1, context.Parts.Count() + 1);
                    car.Parts.Add(context.Parts.FirstOrDefault(p => p.Id == partIndex));
                }
                context.Cars.Add(car);
            }
            context.SaveChanges();
        }

        private static void SeedParts()
        {
            CarDealerContext context = new CarDealerContext();
            string partsJson = File.ReadAllText("../../../datasets/parts.json");
            IEnumerable<Part> parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(partsJson);
            Random rnd = new Random();
            foreach (var part in parts)
            {
                int rndNumber = rnd.Next(1, context.Suplliers.Count() + 1);
                part.Supllier = context.Suplliers.FirstOrDefault(r => r.Id == rndNumber);
                context.Parts.Add(part);
            }
            context.SaveChanges();
        }

        private static void SeedSuplliers()
        {
            CarDealerContext context = new CarDealerContext();
            string supllierJson = File.ReadAllText("../../../datasets/suppliers.json");
            IEnumerable<Supllier> importSupplier = JsonConvert.DeserializeObject<IEnumerable<Supllier>>(supllierJson);
            context.Suplliers.AddRange(importSupplier);
            context.SaveChanges();
        }
    }
}
