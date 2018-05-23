namespace TitanWebAPI.Models.Alerts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Alert
    {
        public int ID { get; set; }

        public int? AlertSourceID { get; set; }

        public virtual AlertSource AlertSource { get; set; }

        public int? AlertReasonID { get; set; }

        public virtual AlertReason AlertReason { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ParticipantID { get; set; }

        public virtual Participant Participant { get; set; }

        public int? DocumentID { get; set; }

        public virtual ParticipantDocument Document { get; set; }

        public bool? Cleared { get; set; }

        public DateTime? ClearedDate { get; set; }

        [StringLength(200)]
        public string Clarification { get; set; }

        public int? ClearedBy { get; set; }
    }
}
