namespace TitanWebAPI.Models.Financial
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FinancialModel : DbContext
    {
        public FinancialModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<ParticipantProfile> ParticipantProfiles { get; set; }
        public virtual DbSet<ProfileAccount> ProfileAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantProfile>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProfileAccount>()
                .Property(e => e.Code)
                .IsUnicode(false);
        }
    }
}
