using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctor
    {
        private ICollection<Visitation> visitations;

        public Doctor()
        {
            this.visitations = new HashSet<Visitation>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
