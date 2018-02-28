namespace TitanWebAPI.Models.Roadmaps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Phase
    {

        public Phase()
        {
            Milestones = new HashSet<Milestone>();
        }

        public int ID { get; set; }

        public int RoadmapID { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Milestone> Milestones { get; set; }

    }
}
