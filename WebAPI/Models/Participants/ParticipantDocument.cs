using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantDocument
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType Type { get; set; }
        public int ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
        public string DocumentCode { get; set; }
        public DateTime? ExpeditionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string FilePath { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
