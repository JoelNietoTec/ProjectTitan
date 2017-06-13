namespace TitanWebAPI.Models.Params
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParamMaster")]
    public partial class ParamMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParamMaster()
        {
            ParamValues = new HashSet<ParamValue>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParamValue> ParamValues { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? ModificateDate { get; set; }
    }
}
