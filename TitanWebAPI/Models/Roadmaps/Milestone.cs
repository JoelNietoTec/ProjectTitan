namespace TitanWebAPI.Models.Roadmaps
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Milestone
    {
        public int ID { get; set; }

        public int PhaseID { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Completion { get; set; }

        public int? RecurrenceID { get; set; }

        public virtual Recurrence Recurrence { get; set; }
    }
}
