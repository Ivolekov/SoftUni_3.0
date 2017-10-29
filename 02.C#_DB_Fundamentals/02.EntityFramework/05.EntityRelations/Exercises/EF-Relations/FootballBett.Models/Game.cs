using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class Game
    {
        public Game()
        {
            this.Bets = new HashSet<Bet>();
        }
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime DateAntTiemOfGame { get; set; }

        public double HomeTeamWinBetRate { get; set; }

        public double AwayTeamWinBetRate { get; set; }

        public double DrawWinBetRate { get; set; }

        public virtual Round Round { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        //•	Games – Id, Home Team, Away Team, Home Goals, Away Goals, Date and Time of Game, Home team Win bet rate, Away Team Win Bet Rate, Draw Game Bet Rate, Round, Competition)
    }
}
