using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Alert
    {
        public int Id { get; set; }
        public int? AlertSourceId { get; set; }
        public int? AlertReasonId { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ParticipantId { get; set; }
        public int? DocumentId { get; set; }
        public bool? Cleared { get; set; }
        public DateTime? ClearedDate { get; set; }
        public string Clarification { get; set; }
        public int? ClearedBy { get; set; }
    }
}
