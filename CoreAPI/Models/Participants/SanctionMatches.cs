using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class SanctionMatches
    {
        public int Id { get; set; }
        public int? SanctionListId { get; set; }
        public int? ParticipantId { get; set; }
        public string SanctionTerm { get; set; }
        public string SanctionComments { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
