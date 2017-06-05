namespace TitanWebAPI.Models.Countries
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CountriesModel : DbContext
    {
        public CountriesModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>();

            modelBuilder.Entity<Country>()
                .Property(e => e.Score)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Region>();
        }
    }
}
