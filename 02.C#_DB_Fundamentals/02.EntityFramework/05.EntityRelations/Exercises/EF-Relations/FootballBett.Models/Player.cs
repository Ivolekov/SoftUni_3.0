using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string SquadNumber { get; set; }

        public virtual Team Team { get; set; }

        public virtual Position Position { get; set; }

        public bool IsCurrentlyInjured { get; set; }
    }
}
