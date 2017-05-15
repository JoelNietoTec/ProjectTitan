namespace TitanWebAPI.Models.Params
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParamsModel : DbContext
    {
        public ParamsModel()
            : base("name=ParamsModel")
        {
        }

        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<ParamMaster> ParamMasters { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParamCategory>()
                .HasMany(e => e.ParamMasters)
                .WithRequired(e => e.ParamCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<ParamMaster>()
                .HasMany(e => e.ParamValues)
                .WithRequired(e => e.ParamMaster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParamValue>()
                .Property(e => e.Score)
                .HasPrecision(10, 2);
        }
    }
}
