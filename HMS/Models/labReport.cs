using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Models
{
    public class labReport
    {
        public patient Patients { get; set; }
        public doctor Doctors { get; set; }

        public int Id { get; set; }
        public int  PatientsId { get; set; }
        public int DoctorsId { get; set; }
        public string Report { get; set; }
    }
}