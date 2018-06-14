namespace TitanWebAPI.Models.Roadmaps
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RoadmapModel : DbContext
    {
        public RoadmapModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<Milestone> Milestones { get; set; }
        public virtual DbSet<Phase> Phases { get; set; }
        public virtual DbSet<Roadmap> Roadmaps { get; set; }
        public virtual DbSet<Recurrence> Recurrences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Milestone>()
                .Property(e => e.Completion)
                .HasPrecision(18, 0);
        }
    }
}
