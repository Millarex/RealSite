﻿using System.ComponentModel.DataAnnotations;

namespace RealSite.Presentation.ViewModels
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }


        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }


        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Password mismatch ")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}
