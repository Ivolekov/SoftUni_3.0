using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSytem.Models.BindingModels
{
    public class AddAuthorBm
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
