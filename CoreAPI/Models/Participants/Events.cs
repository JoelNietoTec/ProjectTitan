using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginHour { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndHour { get; set; }
        public bool FullDay { get; set; }
        public bool? Active { get; set; }
        public bool? Recurring { get; set; }
        public int? MainId { get; set; }
    }
}
