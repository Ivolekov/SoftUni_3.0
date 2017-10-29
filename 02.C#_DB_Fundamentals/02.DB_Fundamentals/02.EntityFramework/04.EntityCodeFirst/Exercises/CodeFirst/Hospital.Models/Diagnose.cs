using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Diagnose
    {
        private ICollection<Patient> patients;
        public Diagnose()
        {
            this.patients = new HashSet<Patient>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Patient> Patients
        {
            get { return this.patients; }
            set { this.patients = value; }
        }
    }
}
