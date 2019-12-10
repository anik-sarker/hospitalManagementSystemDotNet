using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Serialization;

namespace HMS.Models
{
    public class patient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } /// <summary>
                                          /// 
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        
        public string Address { get; set; }

        [Required]
        public string  Sickness { get; set; }
        public string  Allergies { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$" ,ErrorMessage = "Passwords must contain at least six characters, including uppercase, lowercase letters and numbers.")]
        [DataType(DataType.Password)]
    
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}