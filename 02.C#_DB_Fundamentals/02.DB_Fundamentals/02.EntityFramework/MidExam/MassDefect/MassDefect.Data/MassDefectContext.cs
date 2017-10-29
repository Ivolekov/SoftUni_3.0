namespace MassDefect.Data
{
    using Models;
    using System.Data.Entity;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext.cs")
        {
        }

        public IDbSet<Anomaly> Anomalies { get; set; }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<SolarSystem> SolarSystems { get; set; }

        public IDbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasMany<Person>(anomaly => anomaly.Victims)
                .WithMany(per => per.Anomalies)
                .Map(ap =>
                {
                    ap.MapLeftKey("AnomalyId");
                    ap.MapRightKey("PersonId");
                    ap.ToTable("AnomalyVictims");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}