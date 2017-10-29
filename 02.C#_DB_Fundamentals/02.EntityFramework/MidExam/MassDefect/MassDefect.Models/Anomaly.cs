namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }

        public virtual Planet OriginPlanet { get; set; }

        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }
    }
}
