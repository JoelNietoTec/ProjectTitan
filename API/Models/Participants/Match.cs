namespace TitanWebAPI.Models.Participants
{
    public class Match
    {
        public int ID { get; set; }

        public int ComparisonID { get; set; }

        public int ParticipantID { get; set; }

        public virtual Participant Participant { get; set; }

        public string Term1 { get; set; }

        public string Term2 { get; set; }

        public bool Pending { get; set; }

        public bool Confirmed { get; set; }

        public int Score { get; set; }

        public virtual Comparison Comparison { get; set; }

    }
}