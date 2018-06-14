using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<Users> Users { get; set; }

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

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("((165))");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserId)
                    .HasColumnName("CreatedUserID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.FourthName).HasMaxLength(100);

                entity.Property(e => e.GenderId)
                    .HasColumnName("GenderID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LegalRepresentative).HasMaxLength(100);

                entity.Property(e => e.MobilePhone).HasMaxLength(50);

                entity.Property(e => e.ParamMatrixId).HasColumnName("ParamMatrixID");

                entity.Property(e => e.ParticipantTypeId)
                    .HasColumnName("ParticipantTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Pep).HasColumnName("PEP");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PurposeId)
                    .HasColumnName("PurposeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.Score).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.SecondName).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ThirdName).HasMaxLength(100);

                entity.Property(e => e.WebSite).HasMaxLength(100);

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.CreatedUserId)
                    .HasConstraintName("FK_Participants_ToUsers");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("IX_Users_Username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.LastChangePassword).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

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
