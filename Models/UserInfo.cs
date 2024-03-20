using System;
using System.Collections.Generic;

namespace WebAssignment.Models
{
    public partial class UserInfo
    {
        public int? UId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }

        public virtual User? UIdNavigation { get; set; }
    }
}
