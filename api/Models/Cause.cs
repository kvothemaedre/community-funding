using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Cause
    {
        public int Cid { get; set; }
        public string Frid { get; set; }
        public string Reason { get; set; }
        public decimal? Money { get; set; }
    }
}
