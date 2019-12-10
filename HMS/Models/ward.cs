using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Models
{
    public class ward
    {
        public patient Patients { get; set; }
        public doctor Doctors { get; set; }
        public nurse Nurse { get; set; }

        public int Id { get; set; }
        [Required]
        public int PatientsId { get; set; }
        [Required]
        public int DoctorsId { get; set; }
        [Required]
        public int NurseId { get; set; }

        public byte BedId { get; set; }


    }
}