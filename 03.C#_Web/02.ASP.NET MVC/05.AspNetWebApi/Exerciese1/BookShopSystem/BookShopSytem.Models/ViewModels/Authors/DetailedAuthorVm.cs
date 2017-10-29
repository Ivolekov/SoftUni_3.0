namespace BookShopSytem.Models.ViewModels.Authors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DetailedAuthorVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public  IEnumerable<string> BookTitles { get; set; }
    }
}
