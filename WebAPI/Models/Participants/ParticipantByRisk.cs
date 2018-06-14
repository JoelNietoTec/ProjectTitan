namespace WebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParticipantsByRisk")]
    public partial class ParticipantsByRisk
    {

        public string Rate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sort { get; set; }

        public string Icon { get; set; }

        public string ColorType { get; set; }
    }
}
