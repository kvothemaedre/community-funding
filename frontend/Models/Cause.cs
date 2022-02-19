using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Models
{
    public partial class Cause
    {
        public int Cid { get; set; }
        public string Frid { get; set; }

        [Required(ErrorMessage ="Please enter the reason")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        [Range(0,int.MaxValue, ErrorMessage = "Please enter a valid number")]
        public decimal? Money { get; set; }
    }
}
