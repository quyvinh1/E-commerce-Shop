using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Bid { get; set; }
        public string? Bname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
