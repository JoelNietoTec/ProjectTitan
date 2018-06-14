using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ParamSubValues
    {
        public int Id { get; set; }
        public int ParamValueId { get; set; }
        public string DisplayValue { get; set; }
        public string EnglishDisplayValue { get; set; }
        public decimal? Score { get; set; }

        public ParamValues ParamValue { get; set; }
    }
}
