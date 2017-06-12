namespace TitanWebAPI.Models.Params
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ParamCategory
    {

        public int ID { get; set; }

        public int ParamMatrixID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Weighting { get; set; }

    }
}
