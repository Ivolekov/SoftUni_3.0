using BookShopSytem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BookShopSytem.Models.ViewModels.Authors
{
    public class BookAuthorVm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AgeRestriction { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }
    }
}
