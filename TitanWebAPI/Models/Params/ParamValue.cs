namespace TitanWebAPI.Models.Params
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ParamValue
    {
        public int ID { get; set; }

        public int ParamMasterID { get; set; }

        [StringLength(100)]
        public string DisplayValue { get; set; }

        [StringLength(100)]
        public string EnglishDisplayValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Score { get; set; }

        public virtual ParamMaster ParamMaster { get; set; }
    }
}
