using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParamCategory
    {
        public int Id { get; set; }
        public int ParamMatrixId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public decimal? Weighting { get; set; }

    }
}
