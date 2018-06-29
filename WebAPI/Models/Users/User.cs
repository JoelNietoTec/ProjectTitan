using System;
using System.Collections.Generic;

namespace WebAPI.Models.Users
{
    public partial class User
    {
        public int Id { get; set; }
        public int? UserProfileId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastChangePassword { get; set; }
    }
}
