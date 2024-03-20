using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class OrderLine
    {
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
