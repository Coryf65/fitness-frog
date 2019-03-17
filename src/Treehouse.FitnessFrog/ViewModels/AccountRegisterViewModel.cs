using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treehouse.FitnessFrog.ViewModels
{
    /// <summary>
    ///   Register Post Method binds here
    /// </summary>
    public class AccountRegisterViewModel
    {
        // one property per field on our form

        // [Required] = Needed to complete form to use for a username as well
        // [EmailAddress] = we can validate if it is a valid email
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Note: We're using a StringLength attribute here in order to keep things simple. 
        // Identity provides a much better way to validate user passwords using the PasswordValidator class.
        //{0} is the field name, the second index {1} is the maximum length, and the third index {2} is the minimum length. 
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Password { get; set; }

        // Let's use the Display data annotation attribute to refine the label for the ConfirmPassword field.
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}