namespace API.Models.Documents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participant
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string SecondName { get; set; }

        [StringLength(100)]
        public string ThirdName { get; set; }

        [StringLength(100)]
        public string FourthName { get; set; }

        public int GenderID { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int ParticipantTypeID { get; set; }

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [StringLength(100)]
        public string WebSite { get; set; }

        [StringLength(100)]
        public string LegalRepresentative { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string MobilePhone { get; set; }

        public int? ParamMatrixID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Score { get; set; }

        [StringLength(50)]
        public string Rate { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? PurposeID { get; set; }

        public bool? PEP { get; set; }

        public bool? MatrixReady { get; set; }

        public int CountryID { get; set; }

        public bool Status { get; set; }
    }
}
