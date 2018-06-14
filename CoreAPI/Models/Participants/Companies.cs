using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
