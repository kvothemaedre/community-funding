using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Models
{
    public partial class SignInFunder
    {
        [Required(ErrorMessage = "Please enter the username")]
        public string Fid { get; set; }
        
        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
    }
}
