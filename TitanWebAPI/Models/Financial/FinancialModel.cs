namespace TitanWebAPI.Models.Financial
{
    using System.Data.Entity;

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
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankType> BankTypes { get; set; }
        public virtual DbSet<FinancialProfile> FinancialProfiles { get; set; }
        public virtual DbSet<TransactionSource> TransactionSources { get; set; }
        public virtual DbSet<FinancialDashboard> FinancialDashboards { get; set; }
        public virtual DbSet<FinancialProduct> FinancialProducts { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProfileProduct> ProfileProducts { get; set; }

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
