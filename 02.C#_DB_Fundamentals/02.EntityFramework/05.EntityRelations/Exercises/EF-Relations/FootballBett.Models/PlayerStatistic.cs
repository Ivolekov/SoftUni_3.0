using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public Game Game { get; set; }

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public int PlayedMinuts { get; set; }
    }
}
