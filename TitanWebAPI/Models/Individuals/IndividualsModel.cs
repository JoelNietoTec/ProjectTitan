namespace TitanWebAPI.Models.Individuals
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IndividualsModel : DbContext
    {
        public IndividualsModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Individual> Individuals { get; set; }
        public virtual DbSet<IndividualsDocument> IndividualsDocuments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>();

            modelBuilder.Entity<Gender>();

            modelBuilder.Entity<Individual>()
                .HasMany(e => e.IndividualsDocuments);

            modelBuilder.Entity<IndividualsDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);
        }
    }
}
