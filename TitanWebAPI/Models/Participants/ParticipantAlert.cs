namespace TitanWebAPI.Models.Participants
{
    using System;

    public class ParticipantAlert
    {
        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public virtual Participant Participant { get; set; }

        public int AlertTypeID { get; set; }

        public virtual AlertType AlertType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Clarification { get; set; }

        public int? DiscardedUser { get; set; }

        public bool Discard { get; set; }

        public DateTime Date { get; set; }
    }
}