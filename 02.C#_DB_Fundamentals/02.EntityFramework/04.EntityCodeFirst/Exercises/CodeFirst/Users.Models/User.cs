using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Users.Models.Attributes;

namespace Users.Models
{
    public class User
    {
        private string email;

        public User()
        {
            this.Friends = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        [MinLength(4), MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,50}$")]
        public string Password { get; set; }

        [Required]
        [Email]
        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }
        
        [MaxLength(1024*1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Town BornTown { get; set; }

        public virtual Town LivingTown { get; set; }

        public virtual ICollection<User> Friends { get; set; }
    }
}
