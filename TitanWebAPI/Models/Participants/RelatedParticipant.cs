namespace TitanWebAPI.Models.Participants
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RelatedParticipant
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string ThirdName { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual ParticipantType ParticipantType { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }

    }
}