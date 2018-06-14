using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ParamValues
    {
        public ParamValues()
        {
            ParamSubValues = new HashSet<ParamSubValues>();
        }

        public int Id { get; set; }
        public int ParamTableId { get; set; }
        public string DisplayValue { get; set; }
        public string EnglishDisplayValue { get; set; }
        public decimal? Score { get; set; }

        public ParamTables ParamTable { get; set; }
        public ICollection<ParamSubValues> ParamSubValues { get; set; }
    }
}
