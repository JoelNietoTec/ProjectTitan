using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantRelationship
    {
        public int Id { get; set; }
        public int? ParticipantId { get; set; }
        public int? RelatedParticipantId { get; set; }
        public int? RelationshipTypeId { get; set; }
    }
}
