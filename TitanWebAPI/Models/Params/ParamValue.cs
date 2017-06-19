namespace TitanWebAPI.Models.Params
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ParamValue
    {
        public int ID { get; set; }

        public int ParamTableID { get; set; }

        [StringLength(100)]
        public string DisplayValue { get; set; }

        [StringLength(100)]
        public string EnglishDisplayValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Score { get; set; }

        [JsonIgnore]
        public virtual ParamTable ParamTable { get; set; }
    }
}
