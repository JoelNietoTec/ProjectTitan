using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI.Models.Settings;

namespace WebAPI.Models.Params
{
    public partial class ParamsContext : DbContext
    {
        public ParamsContext()
        {
        }

        public ParamsContext(DbContextOptions<ParamsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MatrixType> MatrixTypes { get; set; }
        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<ParamSubValue> ParamSubValues { get; set; }
        public virtual DbSet<ParamTable> ParamTables { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }
        public virtual DbSet<TableType> TableTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatrixType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ParamCategory>(entity =>
            {
                entity.HasIndex(e => new { e.ParamMatrixId, e.EnglishName })
                    .HasName("IX_ParamCategories_EnglishName")
                    .IsUnique();

                entity.HasIndex(e => new { e.ParamMatrixId, e.Name })
                    .HasName("IX_ParamCategories_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParamMatrixId).HasColumnName("ParamMatrixID");

                entity.Property(e => e.Weighting).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<ParamMatrix>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.MatrixTypeId).HasColumnName("MatrixTypeID");

                entity.Property(e => e.ModificateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Param>(entity =>
            {
                entity.HasIndex(e => new { e.ParamCategoryId, e.EnglishName })
                    .HasName("IX_Params_EnglishName")
                    .IsUnique();

                entity.HasIndex(e => new { e.ParamCategoryId, e.Name })
                    .HasName("IX_Params_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParamCategoryId).HasColumnName("ParamCategoryID");

                entity.Property(e => e.ParamTableId).HasColumnName("ParamTableID");

                entity.Property(e => e.Weighting).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<ParamSubValue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisplayValue).HasMaxLength(200);

                entity.Property(e => e.EnglishDisplayValue).HasMaxLength(200);

                entity.Property(e => e.ParamValueId).HasColumnName("ParamValueID");

                entity.Property(e => e.Score).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<ParamTable>(entity =>
            {
                entity.HasIndex(e => e.EnglishName)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.ModificateDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.TableTypeId)
                    .HasColumnName("TableTypeID")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ParamValue>(entity =>
            {
                entity.HasIndex(e => new { e.ParamTableId, e.DisplayValue })
                    .HasName("IX_ParamValues_DisplayValue")
                    .IsUnique();

                entity.HasIndex(e => new { e.ParamTableId, e.EnglishDisplayValue })
                    .HasName("IX_ParamValues_EnglishDisplayValue")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisplayValue).HasMaxLength(100);

                entity.Property(e => e.EnglishDisplayValue).HasMaxLength(100);

                entity.Property(e => e.ParamTableId).HasColumnName("ParamTableID");

                entity.Property(e => e.Score).HasColumnType("numeric(10, 2)");

            });

            modelBuilder.Entity<TableType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }

        public DbSet<WebAPI.Models.Settings.Bank> Bank { get; set; }
    }
}
