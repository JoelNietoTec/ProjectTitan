using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Milestones
    {
        public int Id { get; set; }
        public int PhaseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Completion { get; set; }
        public int? RecurrenceId { get; set; }
    }
}
