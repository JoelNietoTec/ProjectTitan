namespace TitanWebAPI.Models.Tasks
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TasksModel : DbContext
    {
        public TasksModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskStatu> TaskStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsFixedLength();
        }
    }
}
