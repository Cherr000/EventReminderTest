using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventReminder.Models
{
    public class CustomerInformation
    {
        [Key]
        public int customerInfoID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }
        public string Email { get; set; }
    }
}