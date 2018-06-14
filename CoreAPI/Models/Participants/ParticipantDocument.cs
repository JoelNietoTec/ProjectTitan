namespace CoreAPI.Models.Participants
{
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Collections.Generic;
    public partial class ParticipantDocument
    {
        private ParticipantDocument(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public int ParticipantId { get; set; }
        public string DocumentCode { get; set; }
        public DateTime? ExpeditionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string FilePath { get; set; }
        public int? CountryId { get; set; }

        private DocumentType _type;
        private Country _country;

        public DocumentType Type
        {
            get => LazyLoader?.Load(this, ref _type);
            set => _type = value;
        }

        public Country Country
        {
            get => LazyLoader?.Load(this, ref _country);
            set => _country = value;
        }

    }
}
