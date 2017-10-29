namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Planet
    {
        public Planet()
        {
            this.OriginAnomalies = new List<Anomaly>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Star Sun { get; set; }

        public int SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        [NotMapped]
        public virtual ICollection<Anomaly> OriginAnomalies { get; set; }
    }
}
