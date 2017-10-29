using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBett.Models
{
    public class Continent
    {
        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
