namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class ParticipantRelationship
    {
        public int ID { get; set; }

        public int ParticipantID { get; set; }

        [ForeignKey("ParticipantID")]
        public virtual Participant Participant { get; set; }

        public int RelatedParticipantID { get; set; }

        [ForeignKey("RelatedParticipantID")]
        public virtual Participant RelatedParticipant { get; set; }

        public int RelationshipTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("RelationshipTypeID ")]
        public virtual RelationshipType Type { get; set; }
    }
}