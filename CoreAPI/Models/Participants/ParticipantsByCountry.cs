namespace CoreAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParticipantsByCountry")]
    public class ParticipantsByCountry
    {
        [Key]
        public int CountryID { get; set; }

        public int? Value { get; set; }

        public string Country { get; set; }

        public string Code { get; set; }

        public string Abbreviation { get; set; }

    }
}
