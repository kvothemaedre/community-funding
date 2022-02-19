using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Models
{
    public partial class FundReceiver
    {
        [Required(ErrorMessage = "Please enter the username")]
        public string Frid { get; set; }
        
        [Required(ErrorMessage = "Please enter the name")]
        public string Frname { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string Password2 {get; set; }
    }
}
