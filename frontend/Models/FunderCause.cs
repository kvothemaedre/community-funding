using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Models
{
    public partial class FunderCause
    {
        public int Pid { get; set; }
        public int? Cid { get; set; }
        public string Fid { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        [Range(0,int.MaxValue, ErrorMessage = "Please enter a valid number")]
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}
