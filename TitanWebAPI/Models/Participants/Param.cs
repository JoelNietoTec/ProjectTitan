namespace TitanWebAPI.Models.Participants
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Param
    {
        public int ID { get; set; }

        public int ParamCategoryID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int ParamTableID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Weighting { get; set; }

    }
}
