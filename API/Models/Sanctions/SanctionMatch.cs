namespace TitanWebAPI.Models.Sanctions
{
    using System;

    public class SanctionMatch
    {
        public int ID { get; set; }

        public int SanctionListID { get; set; }

        public int ParticipantID { get; set; }

        public string SanctionTerm { get; set; }

        public string SanctionComments { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }
    }
}