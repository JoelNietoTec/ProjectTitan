namespace TitanWebAPI.Models.Schedules
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schedule
    {
        public Schedule()
        {
            Milestones = new HashSet<Milestone>();
        }
        public int ID { get; set; }

        public int? Year { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompleteDate { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<Milestone> Milestones { get; set; }
    }
}
