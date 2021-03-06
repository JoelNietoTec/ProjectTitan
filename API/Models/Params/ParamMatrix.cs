namespace TitanWebAPI.Models.Params
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ParamMatrix
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModificateDate { get; set; }

        public int MatrixTypeID { get; set; }

        public virtual MatrixType MatrixType { get; set; }
    }
}
