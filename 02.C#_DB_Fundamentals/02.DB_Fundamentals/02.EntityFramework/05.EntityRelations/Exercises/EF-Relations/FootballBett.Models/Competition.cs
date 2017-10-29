using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class Competition
    {
        public Competition()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public CompetitionType Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
