using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Medicament
    {
        private ICollection<Patient> patients;
        public Medicament()
        {
            this.patients = new HashSet<Patient>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Patient> Patients
        {
            get { return this.patients; }
            set { this.patients = value; }
        }
    }
}
