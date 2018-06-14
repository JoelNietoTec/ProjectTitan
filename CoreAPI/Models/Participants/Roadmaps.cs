using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Roadmaps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Year { get; set; }
        public bool? Active { get; set; }
        public bool? Completed { get; set; }
    }
}
