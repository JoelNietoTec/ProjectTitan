namespace TitanWebAPI.Models.Roadmaps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Roadmap
    {
        public Roadmap()
        {
            Phases = new HashSet<Phase>();
        }
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Phase> Phases { get; set; }

        public int? Year { get; set; }

        public bool? Active { get; set; }

        public bool? Completed { get; set; }
    }
}
