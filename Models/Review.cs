using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string? Review1 { get; set; }
        public DateTime? DatePost { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
