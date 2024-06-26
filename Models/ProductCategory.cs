﻿using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
