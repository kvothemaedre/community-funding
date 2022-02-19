using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class FunderCause
    {
        public int Pid { get; set; }
        public int? Cid { get; set; }
        public string Fid { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}
