using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Login
    {
        [Key]
        public string SessionId { get; set; }

        public virtual User User { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{this.SessionId}/t{this.User.Id}";
        }
    }
}
