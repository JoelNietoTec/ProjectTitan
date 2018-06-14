using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class DiscardMatches
    {
        public int Id { get; set; }
        public int? DiscardId { get; set; }
        public int? SanctionId { get; set; }
        public int? ParticipantId { get; set; }
        public bool? Pending { get; set; }
        public bool? Valid { get; set; }
    }
}
