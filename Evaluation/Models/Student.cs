/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation.Models
{

    public class Student 
    {
        [Key] public int sId { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string studUsername { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string studPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("studPassword", ErrorMessage = "Confirm password and password do not match")]
        [NotMapped]
        public string confirmPassword { get; set; }

        public Guid? activationCode {get; set; }
        public bool? emailVerified { get; set; }
 }

    public class StudentLogIn
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}*/