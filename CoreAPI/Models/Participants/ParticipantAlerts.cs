using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ParticipantAlerts
    {
        public int Id { get; set; }
        public int? ParticipantId { get; set; }
        public int? AlertTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Discard { get; set; }
        public DateTime? Date { get; set; }
        public string Clarification { get; set; }
        public int? DiscardedUser { get; set; }
    }
}
