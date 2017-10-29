namespace MassDefect.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SolarSystem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
