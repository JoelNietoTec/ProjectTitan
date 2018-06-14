using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Matches
    {
        public int Id { get; set; }
        public int? ComparisonId { get; set; }
        public int? ParticipantId { get; set; }
        public string Term1 { get; set; }
        public string Term2 { get; set; }
        public bool? Pending { get; set; }
        public bool? Confirmed { get; set; }
        public int? Score { get; set; }
    }
}
