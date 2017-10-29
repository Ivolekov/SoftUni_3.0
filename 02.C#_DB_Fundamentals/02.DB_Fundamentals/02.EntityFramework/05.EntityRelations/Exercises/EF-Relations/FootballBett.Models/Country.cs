using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBett.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
            this.Continents = new HashSet<Continent>();
        }
        [Key, StringLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

        public virtual ICollection<Continent> Continents { get; set; }
    }
}
