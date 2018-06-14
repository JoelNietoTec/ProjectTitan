using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class User
    {
        public int Id { get; set; }
        public int? UserProfileId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Active { get; set; }
    }
}
