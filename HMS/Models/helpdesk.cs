using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Models
{
    public class helpdesk
    {
        public int Id { get; set; }
        [Required]
        public string  ReportTitle { get; set; }
        [Required]
        public string ReportMessage { get; set; }

    }
}