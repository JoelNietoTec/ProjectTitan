namespace TitanWebAPI.Models.Participants
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Participant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Participant()
        {
            ParticipantContacts = new HashSet<ParticipantContact>();
            /*Nationalities = new HashSet<ParticipantCountry>();*/
        }

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

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string WebSite { get; set; }

        [StringLength(100)]
        public string LegalRepresentative { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string MobilePhone { get; set; }

        public int CountryID { get; set; }

        public virtual ParticipantCountry Country { get; set; }

        public virtual Gender Gender { get; set; }

        public int ParticipantTypeID { get; set; }

        public virtual ParticipantType ParticipantType { get; set; }

        public int ParamMatrixID { get; set; }

        public decimal? Score { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }


        public string FullName
        {
            get
            {
                if (ParticipantTypeID == 1)
                    return ThirdName + " " + FourthName + ", " + FirstName + " " + SecondName;
                else
                    return FirstName;
            }
        }

        public string ShortName
        {
            get
            {
                if (ParticipantTypeID == 1)
                    return FirstName + " " + ThirdName;
                else
                    return SecondName;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }

        [JsonIgnore]
        public virtual ParamMatrix ParamMatrix { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParticipantContact> ParticipantContacts { get; set; }

        public Boolean PEP { get; set; }

        public Boolean? MatrixReady { get; set; }

        /*public virtual ICollection<ParticipantCountry> Nationalities { get; set; }*/
    }
}