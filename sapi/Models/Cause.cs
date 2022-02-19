using System;
using System.Collections.Generic;

#nullable disable

namespace sapi.Models
{
    public partial class Cause
    {
        public int Cid { get; set; }
        public string Frid { get; set; }
        public string Reason { get; set; }
        public decimal? Money { get; set; }
    }
}
