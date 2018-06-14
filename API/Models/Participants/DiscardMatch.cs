namespace TitanWebAPI.Models.Participants
{
    public partial class DiscardMatch
    {
        public int ID { get; set; }

        public int? DiscardID { get; set; }

        public int? SanctionID { get; set; }

        public virtual Sanction Sanction { get; set; }

        public int? ParticipantID { get; set; }

        public virtual Participant Participant { get; set; }

        public bool? Pending { get; set; }

        public bool? Valid { get; set; }
    }
}
