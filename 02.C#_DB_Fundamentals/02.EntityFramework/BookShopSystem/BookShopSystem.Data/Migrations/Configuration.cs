namespace BookShopSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookShopSystem.Data.BookShopContext";
        }
        protected override void Seed(BookShopContext context)
        {

            //var random = new Random();

            //using (var reader = new StreamReader("books.txt"))
            //{
            //    if (context.Books.Any())
            //    {
            //        return;
            //    }
            //    var line = reader.ReadLine();
            //    var authors = context.Author.ToList();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(new[] { ' ' }, 6);
            //        var authorIndex = random.Next(0, authors.Count());
            //        var author = authors[authorIndex];
            //        var edition = (EditionType)int.Parse(data[0]);
            //        var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
            //        var copies = int.Parse(data[2]);
            //        var price = decimal.Parse(data[3]);
            //        var ageRestriction = (AgeRestriction)int.Parse(data[4]);
            //        var title = data[5];

            //        context.Books.Add(new Book()
            //        {
            //            Author = author,
            //            Edition = edition,
            //            ReleaseDate = releaseDate,
            //            Copies = copies,
            //            Price = price,
            //            AgeRestriction = ageRestriction,
            //            Title = title
            //        });

            //        line = reader.ReadLine();
            //        context.SaveChanges();
            //    }
            //}

            //using (var reader = new StreamReader("categories.txt"))
            //{
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(' ');
            //        var categoryName = data[0];

            //        if (context.Categories.Any())
            //        {
            //            return;
            //        }
            //        context.Categories.Add(new Category()
            //        {
            //            Name = categoryName
            //        });

            //        line = reader.ReadLine();
            //        context.SaveChanges();
            //    }
            //}

            //using (var reader = new StreamReader("authors.txt"))
            //{
            //    if (context.Author.Any())
            //    {
            //        return;
            //    }

            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(' ');
            //        var authorFirstname = data[0];
            //        var authorLastname = data[1];

            //        context.Author.Add(new Author()
            //        {
            //            FirstName = authorFirstname,
            //            LastName = authorLastname
            //        });

            //        line = reader.ReadLine();
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
