using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        //•	Position – Id (2 letters – GK, DF, MF, FW…), position description (for example – goal keeper, defender…)
        [Key, StringLength(2)]
        public string Id { get; set; }

        [Required]
        public string PositionDescription { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}
