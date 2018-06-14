using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Params
{
    public partial class ParamSubValue
    {
        public int Id { get; set; }
        public int ParamValueId { get; set; }
        public string DisplayValue { get; set; }
        public string EnglishDisplayValue { get; set; }
        public decimal? Score { get; set; }

    }
}
