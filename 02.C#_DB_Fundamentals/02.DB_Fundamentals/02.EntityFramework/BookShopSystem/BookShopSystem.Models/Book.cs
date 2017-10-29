namespace BookShopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Book
    {
        private ICollection<Category> categories;
        public Book()
        {
            this.categories = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType Edition { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public DateTime ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}
