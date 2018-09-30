using System;

namespace WebAPI.Models.Discards
{
    public partial class SanctionMatch
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
        public int SanctionListId { get; set; }
        public virtual SanctionList SanctionList { get; set; }
        public string SanctionTerm { get; set; }
        public string SanctionComments { get; set; }
        public DateTime Date { get;  set; }
        public char Status { get; set; }
    }
}