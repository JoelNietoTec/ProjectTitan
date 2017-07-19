namespace TitanWebAPI.Models.Participants
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ParamValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParamValue()
        {
            ParamSubValues = new HashSet<ParamSubValue>();
        }

        public int ID { get; set; }

        public int ParamTableID { get; set; }

        [StringLength(100)]
        public string DisplayValue { get; set; }

        [StringLength(100)]
        public string EnglishDisplayValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Score { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParamSubValue> ParamSubValues { get; set; }

        [JsonIgnore]
        public virtual ParamTable ParamTable { get; set; }
    }
}
