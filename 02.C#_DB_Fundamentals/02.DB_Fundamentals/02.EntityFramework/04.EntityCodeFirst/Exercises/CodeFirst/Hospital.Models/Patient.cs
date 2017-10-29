using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    //has first name, last name, address, email
    public class Patient
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime dateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        public bool MedicalInsurance { get; set; }

        public int DiagnoseId { get; set; }

        public int VisitationId { get; set; }

        public int MedicamentId { get; set; }
    }
}
