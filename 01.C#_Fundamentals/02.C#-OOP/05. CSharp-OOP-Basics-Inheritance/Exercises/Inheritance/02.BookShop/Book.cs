using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BookShop
{
    class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            protected set
            {
                string[] authorName = value.Split(' ');
                if (authorName.Length > 1)
                {
                   
                    string authorLastName = authorName[1];
                    string c = authorLastName.Substring(0, 1);
                   
                    if (Char.IsDigit(c, 0))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                this.author = value;
                
            }
        }

        public virtual double Price
        {
            get { return this.price; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name)
                .Append(Environment.NewLine)
                .Append("Title: ").Append(this.Title)
                .Append(Environment.NewLine)
                .Append("Author: ").Append(this.Author)
                .Append(Environment.NewLine)
                .Append(String.Format($"Price: {this.Price:F1}"))
                .Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
