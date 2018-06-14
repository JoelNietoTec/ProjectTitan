using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParamValues
    {

        public int Id { get; set; }
        public int ParamTableId { get; set; }
        public string DisplayValue { get; set; }
        public string EnglishDisplayValue { get; set; }
        public decimal? Score { get; set; }

        public virtual ParamTables ParamTable { get; set; }
        public virtual ICollection<ParamSubValues> ParamSubValues { get; set; }
    }
}
