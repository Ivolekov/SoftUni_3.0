namespace FootballBet.Data
{
    using FootballBett.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FootballBetContext : DbContext
    {
        // Your context has been configured to use a 'FootballBetContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FootballBet.Data.FootballBetContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FootballBetContext' 
        // connection string in the application configuration file.
        public FootballBetContext()
            : base("FootballBetContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BetGame>().HasKey(bg => new { bg.BetId, bg.GameId });
            modelBuilder.Entity<PlayerStatistic>().HasKey(ps => new { ps.GameId, ps.PlayerId });
            base.OnModelCreating(modelBuilder);
        }
        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<BetGame> BetGames { get; set; }

        public IDbSet<Color> Colors { get; set; }

        public IDbSet<Competition> Competitions { get; set; }

        public IDbSet<CompetitionType> CompetitionTypes { get; set; }

        public IDbSet<Continent> Continents { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public IDbSet<Position> Position { get; set; }

        public IDbSet<ResultPrediction> ResultPrediction { get; set; }

        public IDbSet<Round> Rounds { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}