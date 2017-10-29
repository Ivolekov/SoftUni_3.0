using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(1024*1024)]
        public byte[] Logo { get; set; }

        [StringLength(3), Required]
        public string Initials { get; set; }

        public virtual Color PrimaryColor { get; set; }

        public virtual Color SecondaryColor { get; set; }

        public virtual Town Town { get; set; }

        [Required]
        public decimal Buget { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
