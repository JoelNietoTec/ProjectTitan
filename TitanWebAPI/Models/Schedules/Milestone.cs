namespace TitanWebAPI.Models.Schedules
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Milestone
    {
        public Milestone()
        {
            Jobs = new HashSet<Job>();
        }

        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Title { get; set; }

        public int? ScheduleID { get; set; }

        [Column(TypeName = "ntext")]
        public string Goal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompleteDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Completion { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
