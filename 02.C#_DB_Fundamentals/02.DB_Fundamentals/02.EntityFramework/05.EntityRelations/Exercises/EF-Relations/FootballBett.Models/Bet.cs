using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class Bet
    {
        public Bet()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime DateTimeOfBet { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ResultPrediction PredictionResult { get; set; }
    }
}
