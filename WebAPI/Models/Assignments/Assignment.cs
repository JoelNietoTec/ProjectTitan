using System;
using System.Collections.Generic;

namespace WebAPI.Models.Assignments
{
    public partial class Assignment
    {
        public int Id { get; set; }
        public int AssignmentTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? AssignedUserId { get; set; }
        public int? ParticipantId { get; set; }
        public int? ProgressId { get; set; }
    }
}
