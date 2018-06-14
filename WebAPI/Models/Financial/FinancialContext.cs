using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI.Models.Financial;

namespace WebAPI.Models.Financial
{
    public partial class FinancialContext : DbContext
    {
        public FinancialContext()
        {
        }

        public FinancialContext(DbContextOptions<FinancialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankType> BankTypes { get; set; }
        public virtual DbSet<ParticipantProfile> ParticipantProfiles { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionSource> TransactionSources { get; set; }
        public virtual DbSet<FinancialDashboard> FinancialDashboards { get; set; }
        public virtual DbSet<FinancialProfile> FinancialProfiles { get; set; }
        public virtual DbSet<FinancialProduct> FinancialProducts { get; set; }
        public virtual DbSet<ProfileProduct> ProfileProducts { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankTypeId).HasColumnName("BankTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortName).HasMaxLength(50);
            });

            modelBuilder.Entity<BankType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ParticipantProfile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MonthlyExpenseLimit).HasColumnType("money");

                entity.Property(e => e.MonthlyIncomeLimit).HasColumnType("money");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.ParticipantProfileId).HasColumnName("ParticipantProfileID");

                entity.Property(e => e.ProfileProductId)
                    .HasColumnName("ProfileProductID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.TransactionSourceId)
                    .HasColumnName("TransactionSourceID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
            });

            modelBuilder.Entity<TransactionSource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
