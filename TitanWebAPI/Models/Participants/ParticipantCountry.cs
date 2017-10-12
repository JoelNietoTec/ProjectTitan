namespace TitanWebAPI.Models.Participants
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Countries")]
    public class ParticipantCountry
    {
        public ParticipantCountry()
        {
            Participants = new HashSet<Participant>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [StringLength(10)]
        public string Abbreviation { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [JsonIgnore]
        public virtual ICollection<Participant> Participants { get; set; }
    }
}