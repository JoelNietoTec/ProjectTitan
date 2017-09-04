namespace TitanWebAPI.Models.Countries
{
    using System.Data.Entity;

    public partial class CountriesModel : DbContext
    {
        public CountriesModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>();
        }
    }
}
