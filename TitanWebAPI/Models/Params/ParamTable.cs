namespace TitanWebAPI.Models.Params
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ParamTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParamTable()
        {
            ParamValues = new HashSet<ParamValue>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModificateDate { get; set; }

        public int TableTypeID { get; set; }

        public virtual TableType TableType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParamValue> ParamValues { get; set; }
    }
}
