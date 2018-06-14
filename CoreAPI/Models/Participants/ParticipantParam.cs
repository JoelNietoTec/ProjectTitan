using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ParticipantParam
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ParamMatrixId { get; set; }
        public int ParamCategoryId { get; set; }
        public int ParamId { get; set; }
        public int? ParamValueId { get; set; }
        public int? ParamSubValueId { get; set; }
        public decimal? Score { get; set; }
    }
}
