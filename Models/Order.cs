using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime? DateOrder { get; set; }
        public double? TotalPrice { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
