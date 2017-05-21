namespace TitanWebAPI.Models.Individuals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IndividualsDocument
    {
        public int ID { get; set; }

        public int DocumentTypeID { get; set; }

        public int IndividualID { get; set; }

        [StringLength(50)]
        public string DocumentCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpeditionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(200)]
        public string FilePath { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
