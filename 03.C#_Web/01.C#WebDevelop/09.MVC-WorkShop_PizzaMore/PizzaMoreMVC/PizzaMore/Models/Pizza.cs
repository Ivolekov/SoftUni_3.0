using System.ComponentModel.DataAnnotations;

namespace PizzaMore.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Recipe { get; set; }


        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
    }
}
