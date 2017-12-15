namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParticipantsByCountry")]
    public partial class ParticipantsByCountry
    {
        public int? Value { get; set; }

        [Key]
        [Column(Order = 0)]
        public int CountryID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Country { get; set; }

        public string Code { get; set; }

        public string Abbreviation { get; set; }

    }
}