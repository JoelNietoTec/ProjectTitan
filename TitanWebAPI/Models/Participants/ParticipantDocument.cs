namespace TitanWebAPI.Models.Participants
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ParticipantDocument
    {
        public int ID { get; set; }

        public int DocumentTypeID { get; set; }

        public int ParticipantID { get; set; }

        [StringLength(50)]
        public string DocumentCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpeditionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(200)]
        public string FilePath { get; set; }

        public int CountryID { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual DocumentCountry Country { get; set; }

        public int? FileID { get; set; }

        [ForeignKey("FileID")]
        public virtual Document Document { get; set; }
    }
}
