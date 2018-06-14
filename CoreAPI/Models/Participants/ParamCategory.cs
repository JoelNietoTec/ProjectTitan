using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ParamCategory
    {
        public ParamCategory()
        {
            Params = new HashSet<Param>();
        }

        public int Id { get; set; }
        public int ParamMatrixId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public decimal? Weighting { get; set; }

        public ICollection<Param> Params { get; set; }
    }
}
