using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Models
{
    public partial class Funder
    {
        [Required(ErrorMessage = "Please enter the username")]
        public string Fid { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "The passwords do not match")]
        public string Password2 {get; set; }
    }
}
