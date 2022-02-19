using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class CustomerDetail
    {
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Password { get; set; }
    }
}
