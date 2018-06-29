using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Assignments
{
    public partial class AssignmentsContext : DbContext
    {
        public AssignmentsContext()
        {
        }

        public AssignmentsContext(DbContextOptions<AssignmentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentType> AssignmentTypes { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignedUserId).HasColumnName("AssignedUserID");

                entity.Property(e => e.AssignmentTypeId).HasColumnName("AssignmentTypeID");

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.ProgressId).HasColumnName("ProgressID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<AssignmentType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");


                entity.Property(e => e.ParticipantTypeId)
                    .HasColumnName("ParticipantTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Score).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.SecondName).HasMaxLength(100);

                entity.Property(e => e.ThirdName).HasMaxLength(100);

            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("IX_Users_Username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserProfileId)
                    .HasColumnName("UserProfileID")
                    .HasDefaultValueSql("((1))");
            });
        }
    }
}
