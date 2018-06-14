namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;

    public partial class ParticipantNationality
    {
        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public int CountryID { get; set; }

        public virtual ParticipantCountry Country { get; set; }
    }
}