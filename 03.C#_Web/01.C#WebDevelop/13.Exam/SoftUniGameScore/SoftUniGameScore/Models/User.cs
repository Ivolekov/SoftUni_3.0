namespace SoftUniGameScore.Models
{
    using System.Collections.Generic;
    public class User
    {
        public User()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
