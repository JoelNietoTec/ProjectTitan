namespace TitanWebAPI.Models.Params
{
    using System.Data.Entity;

    public partial class ParamsModel : DbContext
    {
        public ParamsModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<ParamMaster> ParamMasters { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }
        public virtual DbSet<MatrixType> MatrixTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParamCategory>()
                .Property(e => e.Weighting)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ParamCategory>();

            modelBuilder.Entity<ParamMaster>()
                .Property(e => e.FreeField)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParamMaster>()
                .Property(e => e.IsRequired)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParamMaster>()
                .Property(e => e.Weighting)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ParamMaster>();

            modelBuilder.Entity<ParamMatrix>();

            modelBuilder.Entity<ParamValue>()
                .Property(e => e.Score)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MatrixType>();
        }
    }
}
