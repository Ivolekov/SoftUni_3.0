using BookShopSytem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSytem.Models.ViewModels.Books
{
    public class AddBookBm
    {
        [MinLength(1), MaxLength(50), Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }
    }
}
