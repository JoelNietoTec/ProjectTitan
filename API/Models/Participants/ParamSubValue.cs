namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ParamSubValue
    {
        public int ID { get; set; }

        public int ParamValueID { get; set; }

        [StringLength(200)]
        public string DisplayValue { get; set; }

        [StringLength(200)]
        public string EnglishDisplayValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Score { get; set; }

    }
}