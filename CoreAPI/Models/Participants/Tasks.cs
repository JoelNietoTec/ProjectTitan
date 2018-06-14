using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? StatusId { get; set; }
        public int? ParticipantId { get; set; }
        public int? RecurrenceId { get; set; }
    }
}
