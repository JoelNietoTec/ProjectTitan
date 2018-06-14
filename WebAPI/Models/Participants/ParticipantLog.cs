using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantLog
    {
        public int Id { get; set; }
        public int? ParticipantId { get; set; }
        public int? UserId { get; set; }
        public int? TypeId { get; set; }
        public DateTime? ActivityDate { get; set; }
    }
}
