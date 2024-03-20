using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class WishList
    {
        public int WishListId { get; set; }
        public int? ProductId { get; set; }
        public int? UsersId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? Users { get; set; }
    }
}
