namespace TitanWebAPI.Models.Participants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParticipantsByRisk")]
    public partial class ParticipantsByRisk
    {
        public int? Count { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Rate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sort { get; set; }

        public string Icon { get; set; }

        public string ColorType { get; set; }
    }
}
