using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Jobs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? MilestoneId { get; set; }
        public string Goal { get; set; }
        public string Comments { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public decimal? Completion { get; set; }
        public bool? Status { get; set; }
    }
}
