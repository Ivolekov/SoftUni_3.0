using Newtonsoft.Json;
using ProductShop.Data;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //SeedData();
            //1
            //ProductInRange();
            //2
            //SuccessfullySoldProducts();
            //3
            //CategoriesByProductsCount();
            //4
            UsersAndProducts();
        }

        private static void UsersAndProducts()
        {
            ProductShopContext context = new ProductShopContext();
            var users = context.Users
                .Select(user => new
                {
                    usersCount = context.Users.Count(),
                    users = context.Users
                    .Where(p => p.SoldProducts.Count() != 0)
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = u.SoldProducts
                        .Select(p => new
                        {
                            count = u.SoldProducts.Count(),
                            products = u.SoldProducts
                            .Select(pr => new
                            {
                                name = pr.Name,
                                price = pr.Price
                            })
                        })
                    })

                });

            SerilaziedObject(users, "../../../results/users-products.json");
        }

        private static void CategoriesByProductsCount()
        {
            ProductShopContext context = new ProductShopContext();
            var categories = context.Categories
                .Where(c => c.Products.Count() != 0)
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                });

            SerilaziedObject(categories, "../../../results/categories.json");
        }

        private static void SuccessfullySoldProducts()
        {
            ProductShopContext context = new ProductShopContext();
            var users = context.Users
                .Where(u => u.SoldProducts.Count(p => p.Buyer != null) != 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProduct = u.SoldProducts.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                });
            SerilaziedObject(users, "../../../results/users.json");
        }

        private static void ProductInRange()
        {
            ProductShopContext context = new ProductShopContext();
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price < 1000 && p.Buyer == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                });
            SerilaziedObject(products, "../../../results/products.json");
        }

        private static void SerilaziedObject<T>(T enteties, string path)
        {
            string json = JsonConvert.SerializeObject(enteties, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private static void SeedData()
        {
            SeedUsers();
            SeedProducts();
            SeedCategories();

        }

        private static void SeedCategories()
        {
            ProductShopContext context = new ProductShopContext();
            string categoriesJson = File.ReadAllText("../../../datasets/categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(categoriesJson);
            var products = context.Products.ToList();
            Random rnd = new Random();
            foreach (Category category in categories)
            {
                for (int i = 0; i < products.Count / 4; i++)
                {
                    category.Products.Add(products[rnd.Next(0, products.Count)]);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedProducts()
        {
            ProductShopContext context = new ProductShopContext();
            string productsJson = File.ReadAllText("../../../datasets/products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(productsJson);
            Random rnd = new Random();
            int usersCount = context.Users.Count();

            foreach (var product in products)
            {
                product.SellerId = rnd.Next(1, usersCount + 1);
                double hasBuyerFactor = rnd.NextDouble();
                if (hasBuyerFactor <= 0.7)
                {
                    product.BuyerId = rnd.Next(1, usersCount + 1);
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void SeedUsers()
        {
            ProductShopContext context = new ProductShopContext();
            string jsonUsers = File.ReadAllText("../../../datasets/users.json");
            IEnumerable<User> importUsers = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonUsers);
            context.Users.AddRange(importUsers);
            context.SaveChanges();
        }
    }
}
