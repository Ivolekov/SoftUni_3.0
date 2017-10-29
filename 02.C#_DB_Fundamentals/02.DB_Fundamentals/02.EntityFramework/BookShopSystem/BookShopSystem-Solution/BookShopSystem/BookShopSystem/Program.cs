namespace BookShopSystem.Client
{
    using System;
    using System.Linq;
    using Data;
    using BookShopSytem.Models;

    class Program
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();
            //1
            //BooksTitlesByAgeRestriction(context);
            //2
            //GoldenBooks(context);
            //3
            //BooksByPrice(context);
            //4
            //NotReleasedBooks(context);
            //5
            //BookTitlesByCategory(context);
            //6
            //BooksReleasedBeforeDate(context);
            //7
            //AuthorsSearch(context);
            //8
            //BooksSearch(context);
            //9
            //BookTitlesSearch(context);
            //10
            //CountBooks(context);
            //11
            //TotalBookCopies(context);
            //12
            //FindProfit(context);
            //13
            //TODO: MostRecentBooks(context);


            //PrintBooksAfter2000(context);
            //PrintAuthorsWithBookBefore1990(context);
            //AuthorsSortedByNumberOfBooks(context);
            //PrintBooksByGivenAuthor(context);
            //GetCategoriesAnd3BooksOfEach(context);

            // var books = context.Books
            //                     .Take(3)
            //                     .ToList();
            // books[0].RelatedBooks.Add(books[1]);
            // books[1].RelatedBooks.Add(books[0]);
            // books[0].RelatedBooks.Add(books[2]);
            // books[2].RelatedBooks.Add(books[0]);

            // context.SaveChanges();

            //var booksFromQuery = context.Books.Take(3);

            //foreach (var book in booksFromQuery)
            //{
            //    Console.WriteLine("--{0}", book.Title);
            //    foreach (var relatedBook in book.RelatedBooks)
            //    {
            //        Console.WriteLine(relatedBook.Title);
            //    }
            //}
        }

        private static void MostRecentBooks(BookShopContext context)
        {
            var mostRecentBook = context.Categories
                .Where(c => c.Books.Count() != 0);
        }

        private static void FindProfit(BookShopContext context)
        {
            var profits = context.Categories
                .GroupBy(c => new
                {
                    CategoryName = c.Name,
                    CategoriProfit = c.Books.Sum(b => b.Price * b.Copies)
                })
                .OrderByDescending(c=>c.Key.CategoriProfit)
                .ThenBy(c=>c.Key.CategoryName);

            foreach (var profit in profits)
            {
                Console.WriteLine($"{profit.Key.CategoryName} - ${profit.Key.CategoriProfit}");
            }
        }

        private static void TotalBookCopies(BookShopContext context)
        {
            var extractAuthorsAndCountCopies = context.Authors.GroupBy(g => new
            {
                fullname = g.FirstName + " " + g.LastName,
                copies = g.Books.Sum(b => b.Copies)
            }).OrderByDescending(b=>b.Key.copies);

            foreach (var book in extractAuthorsAndCountCopies)
            {
                Console.WriteLine($"{book.Key.fullname} - {book.Key.copies}");
            }
        }

        private static void CountBooks(BookShopContext context)
        {
            Console.Write("Enter: ");
            int num = int.Parse(Console.ReadLine());

            var books = context.Books
                .Count(b => b.Title.Length >= num);
            Console.WriteLine(books);
        }

        private static void BookTitlesSearch(BookShopContext context)
        {
            Console.Write("Enter: ");
            string input = Console.ReadLine();

            var authors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(ab => new
                {
                    title = ab.Title,
                    firstname = ab.Author.FirstName,
                    lastname = ab.Author.LastName
                });

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.title} ({author.firstname} {author.lastname})");
            }
        }

        private static void BooksSearch(BookShopContext context)
        {
            Console.Write("Enter: ");
            string input = Console.ReadLine();

            var books = context.Books
                .Where(b => b.Title.Contains(input))
                .Select(b => b.Title);

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void AuthorsSearch(BookShopContext context)
        {
            Console.Write("Enter: ");
            string input = Console.ReadLine();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    firsname = a.FirstName,
                    lastname = a.LastName
                });

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.firsname} {author.lastname}");
            }
        }

        private static void BooksReleasedBeforeDate(BookShopContext context)
        {
            Console.Write("Enter year: ");
            DateTime input = DateTime.ParseExact(Console.ReadLine(), "dd-mm-yyyy", null);

            var booksBeforeGivendate = context.Books
                .Where(b => b.ReleaseDate < input)
                .Select(b => new
                {
                    title = b.Title,
                    editionType = b.EditionType.ToString(),
                    price = b.Price
                });

            foreach (var book in booksBeforeGivendate)
            {
                Console.WriteLine($"{book.title} ({book.editionType}) ${book.price}");
            }

        }

        private static void BookTitlesByCategory(BookShopContext context)
        {
            Console.Write("Enter category: ");
            var input = Console.ReadLine().Split(' ').ToList();
            var titles = context.Books
                .Where(b => b.Categories.Count(c => input.Contains(c.Name)) != 0)
                .Select(b => b.Title);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static void NotReleasedBooks(BookShopContext context)
        {
            Console.Write("Enter year: ");
            string year = Console.ReadLine();

            var extractNotReletedBooks = context.Books
                .Where(b => b.ReleaseDate.Value.Year.ToString() != year)
                .Select(b => b.Title);

            foreach (var title in extractNotReletedBooks)
            {
                Console.WriteLine(title);
            }

        }

        private static void BooksByPrice(BookShopContext context)
        {
            var extractBookPriceLower5Higher40 = context.Books
                .Where(b => b.Price < 5 || b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                });

            foreach (var bookTitleAndPrice in extractBookPriceLower5Higher40)
            {
                Console.WriteLine($"{bookTitleAndPrice.Title} - ${bookTitleAndPrice.Price:F2}");
            }
        }

        private static void GoldenBooks(BookShopContext context)
        {
            var extraxtGolderBooksLessThen5000Copies = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType.ToString() == "Gold")
                .Select(b => b.Title);

            foreach (var title in extraxtGolderBooksLessThen5000Copies)
            {
                Console.WriteLine(title);
            }
        }

        private static void BooksTitlesByAgeRestriction(BookShopContext context)
        {
            Console.Write("Enter age restriction: ");
            string input = Console.ReadLine();

            var extraxtBookTitlesByAgeRestriction = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == input.ToLower())
                .Select(b => b.Title);

            foreach (var title in extraxtBookTitlesByAgeRestriction)
            {
                Console.WriteLine(title);
            }
        }

        private static void GetCategoriesAnd3BooksOfEach(BookShopContext context)
        {
            var categories = context.Categories.OrderBy(category => category.Books.Count).Select(category => new
            {
                category.Name,
                BooksCount = category.Books.Count,
                Books = category.Books.OrderByDescending(book => book.ReleaseDate).Take(3).Select(book => new
                {
                    book.Title,
                    book.ReleaseDate
                })
            });

            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.Name}: {category.BooksCount} books");
                foreach (var book in category.Books)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate})");
                }
            }
        }

        private static void PrintBooksByGivenAuthor(BookShopContext context)
        {
            var books =
                context.Books.Where(book => book.Author.FirstName == "George" && book.Author.LastName == "Powell")
                    .OrderByDescending(book => book.ReleaseDate)
                    .ThenBy(book => book.Title);
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Title} {book.ReleaseDate} {book.Copies}");
            }
        }

        private static void AuthorsSortedByNumberOfBooks(BookShopContext context)
        {
            var authors = context.Authors.OrderByDescending(author => author.Books.Count);

            foreach (Author author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Books.Count}");
            }
        }

        private static void PrintAuthorsWithBookBefore1990(BookShopContext context)
        {
            var authors =
                context.Authors.Where(
                    author =>
                        author.Books.Count(book => book.ReleaseDate.HasValue && book.ReleaseDate.Value.Year < 1990) != 0);

            foreach (Author author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        private static void PrintBooksAfter2000(BookShopContext context)
        {
            var wantedBooks = context.Books.Where(book => book.ReleaseDate.HasValue && book.ReleaseDate.Value.Year > 2000);
            foreach (Book wantedBook in wantedBooks)
            {
                Console.WriteLine(wantedBook.Title);
            }
        }
    }
}
