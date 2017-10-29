namespace BookShopSystem.ConsoleClient
{
    using Data;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            var books = context.Books.Take(3).ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);
            context.SaveChanges();

            var booksFromQuery = context.Books
                .Take(3)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    RelatedBook = b.RelatedBooks.Select(rb=>rb.Title)
                });

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.BookTitle);
                foreach (var relatedBook in book.RelatedBook)
                {
                    Console.WriteLine(relatedBook);
                }
            }
            //01
            //var books = context.Books
            //    .Where(b => b.ReleaseDate.Year >= 2000)
            //    .Select(b => b.Title);

            //foreach (var book in books)
            //{
            //    Console.WriteLine(book);
            //}
            //02
            //var authors = context.Author
            //    .Where(a => a.Books.Count(b => b.ReleaseDate.Year <= 1990) > 0)
            //    .Select(a => a.FirstName + " " + a.LastName);
            //foreach (var author in authors)
            //{
            //    Console.WriteLine(author);
            //}
            //03
            //var authors = context.Author.Where(a => a.Books.Count > 0)
            //    .OrderByDescending(b => b.Books.Count)
            //    .Select(a => a.FirstName + " " + a.LastName + " " + a.Books.Count);

            //foreach (var author in authors)
            //{
            //    Console.WriteLine(author);
            //}

            //04
            //var books = context.Books
            //    .Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
            //    .OrderByDescending(b => b.ReleaseDate)
            //    .ThenBy(b => b.Title)
            //    .Select(b => b.Title + " " + b.ReleaseDate + " " + b.Copies);

            //foreach (var book in books)
            //{
            //    Console.WriteLine(book);
            //}

            //05
        }
    }
}
