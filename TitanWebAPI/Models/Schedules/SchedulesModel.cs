namespace TitanWebAPI.Models.Schedules
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchedulesModel : DbContext
    {
        public SchedulesModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Milestone> Milestones { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .Property(e => e.Completion)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Milestone>()
                .Property(e => e.Completion)
                .HasPrecision(5, 2);
        }
    }
}
