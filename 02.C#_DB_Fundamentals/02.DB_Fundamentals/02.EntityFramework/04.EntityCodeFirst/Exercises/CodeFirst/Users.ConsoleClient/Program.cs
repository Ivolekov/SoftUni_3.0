using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Data;
using Users.Models;
using System.Data.Entity.Validation;

namespace Users.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext context = new UserContext();
            using (context)
            {



                //Town town = new Town()
                //{
                //    Name = "Sofia",
                //    Country = "Bulgaria"
                //};
                //User user = new User()
                //{
                //    Username = "sashko",
                //    Password = "Ivo87*#*",
                //    Email = "alex76@abv.bg",
                //    ProfilePicture = File.ReadAllBytes(@"C:\Users\Ivo\Desktop\aida (2).jpg"),
                //    RegisteredOn = new DateTime(2017, 05, 07),
                //    LastTimeLoggedIn = new DateTime(2015, 11, 04),
                //    Age = 45,
                //    IsDeleted = true,
                //    FirstName = "Aleksandar",
                //    LastName = "Ivanov"
                //};

                //context.Towns.Add(town);
                //context.Users.Add(user);
                //Town sofia = context.Towns.First(t => t.Name == "Sofia");
                //context.Users.First().BornTown = sofia;

                try
                {
                    //context.SaveChanges();
                    var user = context.Users.Where(u => u.Id == 1);
                    foreach (var u in user)
                    {
                        Console.WriteLine(u.FullName);
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var ms in ex.EntityValidationErrors)
                    {
                        foreach (var m in ms.ValidationErrors)
                        {
                            Console.WriteLine(m.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
