using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            WishLists = new HashSet<WishList>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
