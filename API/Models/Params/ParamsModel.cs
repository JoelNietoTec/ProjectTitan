namespace TitanWebAPI.Models.Params
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParamsModel : DbContext
    {
        public ParamsModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<MatrixType> MatrixTypes { get; set; }
        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<ParamTable> ParamTables { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }
        public virtual DbSet<TableType> TableTypes { get; set; }
        public virtual DbSet<ParamSubValue> ParamSubValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatrixType>()
                .HasMany(e => e.ParamMatrices)
                .WithRequired(e => e.MatrixType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParamCategory>()
                .Property(e => e.Weighting)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ParamCategory>()
                .HasMany(e => e.Params)
                .WithRequired(e => e.ParamCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Param>()
                .Property(e => e.Weighting)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ParamValue>()
                .Property(e => e.Score)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ParamValue>()
                .HasMany(e => e.ParamSubValues)
                .WithRequired(e => e.ParamValue)
                .WillCascadeOnDelete(false);
        }
    }
}
