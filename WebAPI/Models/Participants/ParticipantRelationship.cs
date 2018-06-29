using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantRelationship
    {
        public int Id { get; set; }
        public int? ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
        public int? RelatedParticipantId { get; set; }
        public virtual Participant RelatedParticipant { get; set; }
        public int? RelationshipTypeId { get; set; }
        public virtual RelationshipType Type { get; set; }
    }
}
