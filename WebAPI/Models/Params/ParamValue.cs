using System.Collections.Generic;

namespace WebAPI.Models.Params
{
    public partial class ParamValue
    {
        public int Id { get; set; }
        public int ParamTableId { get; set; }
        public string DisplayValue { get; set; }
        public string EnglishDisplayValue { get; set; }
        public decimal? Score { get; set; }

        public virtual ICollection<ParamSubValue> SubValues { get; set; }
    }
}
