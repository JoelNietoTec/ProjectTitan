using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantMatrices
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ParamMatrixId { get; set; }
        public int? Active { get; set; }
        public decimal? Score { get; set; }
    }
}
