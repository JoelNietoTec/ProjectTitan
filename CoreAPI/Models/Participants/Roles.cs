using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
    }
}
