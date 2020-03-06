using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Your full name")]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Zip or Postal Code")]
        public string Zip { get; set; }

    }
}
