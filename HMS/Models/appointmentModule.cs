using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HMS.Models
{
    public class appointmentModule
    {
        public patient Patients { get; set; }
        public doctor Doctors { get; set; }

        public int Id { get; set; }

        public int PatientsId { get; set; }
        public int DoctorsId { get; set; }

        [Display(Name = "Set the Appointment Time")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDateTime { get; set; }

        public string Sickness { get; set; }

    }
}