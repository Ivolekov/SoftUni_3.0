using BookShopSytem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSytem.Models.ViewModels.Books
{
    public class DetailedBookVm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AgeRestriction { get; set; }

        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }
    }
}
