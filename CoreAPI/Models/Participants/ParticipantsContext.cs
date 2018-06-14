using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreAPI.Models.Participants
{
    public partial class ParticipantsContext : DbContext
    {
        public ParticipantsContext()
        {
        }

        public ParticipantsContext(DbContextOptions<ParticipantsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<AlertPriorities> AlertPriorities { get; set; }
        public virtual DbSet<AlertReasons> AlertReasons { get; set; }
        public virtual DbSet<Alerts> Alerts { get; set; }
        public virtual DbSet<AlertSources> AlertSources { get; set; }
        public virtual DbSet<AlertTypes> AlertTypes { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<BankTypes> BankTypes { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Comparisons> Comparisons { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DiscardMatches> DiscardMatches { get; set; }
        public virtual DbSet<Discards> Discards { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<FinancialProducts> FinancialProducts { get; set; }
        public virtual DbSet<Frecuencies> Frecuencies { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Lists> Lists { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<MatrixTypes> MatrixTypes { get; set; }
        public virtual DbSet<Milestones> Milestones { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<NotificationTypes> NotificationTypes { get; set; }
        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<ParamSubValues> ParamSubValues { get; set; }
        public virtual DbSet<ParamTables> ParamTables { get; set; }
        public virtual DbSet<ParamValues> ParamValues { get; set; }
        public virtual DbSet<ParticipantAlerts> ParticipantAlerts { get; set; }
        public virtual DbSet<ParticipantContacts> ParticipantContacts { get; set; }
        public virtual DbSet<ParticipantDocument> ParticipantDocuments { get; set; }
        public virtual DbSet<ParticipantLog> ParticipantLog { get; set; }
        public virtual DbSet<ParticipantMatrices> ParticipantMatrices { get; set; }
        public virtual DbSet<ParticipantMatrixValues> ParticipantMatrixValues { get; set; }
        public virtual DbSet<ParticipantNationalities> ParticipantNationalities { get; set; }
        public virtual DbSet<ParticipantParam> ParticipantParams { get; set; }
        public virtual DbSet<ParticipantProfiles> ParticipantProfiles { get; set; }
        public virtual DbSet<ParticipantRelationship> ParticipantRelationships { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ParticipantType> ParticipantTypes { get; set; }
        public virtual DbSet<Phases> Phases { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<ProfileAccounts> ProfileAccounts { get; set; }
        public virtual DbSet<ProfileProducts> ProfileProducts { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Recurrences> Recurrences { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<Roadmaps> Roadmaps { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SanctionedItems> SanctionedItems { get; set; }
        public virtual DbSet<SanctionLists> SanctionLists { get; set; }
        public virtual DbSet<SanctionMatches> SanctionMatches { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<TableTypes> TableTypes { get; set; }
        public virtual DbSet<TaskCategories> TaskCategories { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<TransactionSources> TransactionSources { get; set; }
        public virtual DbSet<TransactionTypes> TransactionTypes { get; set; }
        public virtual DbSet<UserCompanies> UserCompanies { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<XmlwithOpenXml> XmlwithOpenXml { get; set; }
        public virtual DbSet<PendingDocument> PendingDocuments { get; set; }
        public virtual DbSet<ParticipantsByRisk> ParticipantsByRisk { get; set; }
        public virtual DbSet<ParticipantsByCountry> ParticipantsByCountry { get; set; }

        // Unable to generate entity type for table 'dbo.sdn'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Sanctions'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AlertPriorities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AlertReasons>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__tmp_ms_x__A25C5AA74BD0B879")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlertPriorityId)
                    .HasColumnName("AlertPriorityID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AlertSourceId).HasColumnName("AlertSourceID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Alerts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlertReasonId).HasColumnName("AlertReasonID");

                entity.Property(e => e.AlertSourceId).HasColumnName("AlertSourceID");

                entity.Property(e => e.Clarification).HasMaxLength(200);

                entity.Property(e => e.Cleared).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClearedDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            });

            modelBuilder.Entity<AlertSources>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AlertTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankTypeId).HasColumnName("BankTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortName).HasMaxLength(50);
            });

            modelBuilder.Entity<BankTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ShortName).HasMaxLength(10);
            });

            modelBuilder.Entity<Comparisons>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.File)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abbreviation).HasMaxLength(10);

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DiscardMatches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiscardId).HasColumnName("DiscardID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Pending).HasDefaultValueSql("((1))");

                entity.Property(e => e.SanctionId).HasColumnName("SanctionID");

                entity.Property(e => e.Valid).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Discards>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ListId).HasColumnName("ListID");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RequiredEntity).HasDefaultValueSql("((0))");

                entity.Property(e => e.RequiredIndividual).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MainId).HasColumnName("MainID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath).HasMaxLength(200);
            });

            modelBuilder.Entity<FinancialProducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");
            });

            modelBuilder.Entity<Frecuencies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.Comments).HasColumnType("ntext");

                entity.Property(e => e.CompleteDate).HasColumnType("date");

                entity.Property(e => e.Completion).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Goal).HasColumnType("ntext");

                entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");

                entity.Property(e => e.Title).HasColumnType("ntext");
            });

            modelBuilder.Entity<Lists>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComparisonId).HasColumnName("ComparisonID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Term1).HasMaxLength(200);

                entity.Property(e => e.Term2).HasMaxLength(200);
            });

            modelBuilder.Entity<MatrixTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Milestones>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Completion).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PhaseId).HasColumnName("PhaseID");

                entity.Property(e => e.RecurrenceId).HasColumnName("RecurrenceID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Months>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ShortName).HasMaxLength(5);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            });

            modelBuilder.Entity<NotificationTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
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

                entity.HasOne(d => d.MatrixType)
                    .WithMany(p => p.ParamMatrices)
                    .HasForeignKey(d => d.MatrixTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParamMatrices_ToMatrixTypes");
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

                entity.HasOne(d => d.ParamCategory)
                    .WithMany(p => p.Params)
                    .HasForeignKey(d => d.ParamCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Params_ToCategories");

                entity.HasOne(d => d.ParamTable)
                    .WithMany(p => p.Params)
                    .HasForeignKey(d => d.ParamTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Params_ToParamTable");
            });

            modelBuilder.Entity<ParamSubValues>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisplayValue).HasMaxLength(200);

                entity.Property(e => e.EnglishDisplayValue).HasMaxLength(200);

                entity.Property(e => e.ParamValueId).HasColumnName("ParamValueID");

                entity.Property(e => e.Score).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.ParamValue)
                    .WithMany(p => p.ParamSubValues)
                    .HasForeignKey(d => d.ParamValueId)
                    .HasConstraintName("FK_ParamSubValues_ToParamValue");
            });

            modelBuilder.Entity<ParamTables>(entity =>
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

            modelBuilder.Entity<ParamValues>(entity =>
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

                entity.HasOne(d => d.ParamTable)
                    .WithMany(p => p.ParamValues)
                    .HasForeignKey(d => d.ParamTableId)
                    .HasConstraintName("FK_ParamValues_ToTables");
            });

            modelBuilder.Entity<ParticipantAlerts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlertTypeId).HasColumnName("AlertTypeID");

                entity.Property(e => e.Clarification).HasColumnType("text");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            });

            modelBuilder.Entity<ParticipantContacts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.MobilePhone).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<ParticipantDocument>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DocumentCode).HasMaxLength(50);

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.ExpeditionDate).HasColumnType("date");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            });

            modelBuilder.Entity<ParticipantLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ParticipantMatrices>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParamMatrixId).HasColumnName("ParamMatrixID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Score).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<ParticipantMatrixValues>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ParticipantNationalities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            });

            modelBuilder.Entity<ParticipantParam>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParamCategoryId).HasColumnName("ParamCategoryID");

                entity.Property(e => e.ParamId).HasColumnName("ParamID");

                entity.Property(e => e.ParamMatrixId).HasColumnName("ParamMatrixID");

                entity.Property(e => e.ParamSubValueId).HasColumnName("ParamSubValueID");

                entity.Property(e => e.ParamValueId).HasColumnName("ParamValueID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Score).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<ParticipantProfiles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MonthlyExpenseLimit).HasColumnType("money");

                entity.Property(e => e.MonthlyIncomeLimit).HasColumnType("money");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<ParticipantRelationship>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.RelatedParticipantId).HasColumnName("RelatedParticipantID");

                entity.Property(e => e.RelationshipTypeId).HasColumnName("RelationshipTypeID");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("((165))");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.FourthName).HasMaxLength(100);

                entity.Property(e => e.GenderId)
                    .HasColumnName("GenderID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LegalRepresentative).HasMaxLength(100);

                entity.Property(e => e.MobilePhone).HasMaxLength(50);

                entity.Property(e => e.ParamMatrixId).HasColumnName("ParamMatrixID");

                entity.Property(e => e.ParticipantTypeId)
                    .HasColumnName("ParticipantTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedUserId)
                    .HasColumnName("CreatedUserID");

                entity.Property(e => e.Pep).HasColumnName("PEP");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PurposeId)
                    .HasColumnName("PurposeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Score).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.SecondName).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ThirdName).HasMaxLength(100);

                entity.Property(e => e.WebSite).HasMaxLength(100);
            });

            modelBuilder.Entity<ParticipantType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Phases>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.RoadmapId).HasColumnName("RoadmapID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ProfileAccounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyExpenseLimit)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MonthlyIncomeLimit)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ParticipantProfileId).HasColumnName("ParticipantProfileID");
            });

            modelBuilder.Entity<ProfileProducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.FinancialProductId).HasColumnName("FinancialProductID");

                entity.Property(e => e.MonthlyPayment)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ParticipantProfileId).HasColumnName("ParticipantProfileID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(10);

                entity.Property(e => e.EndDate).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Recurrences>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RelationshipType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Roadmaps>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanctionedItems>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasColumnType("text");

                entity.Property(e => e.Country).HasMaxLength(400);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.Nationality).HasMaxLength(400);

                entity.Property(e => e.Term1).HasMaxLength(400);

                entity.Property(e => e.Term2).HasMaxLength(400);

                entity.Property(e => e.Term3).HasMaxLength(400);

                entity.Property(e => e.Term4).HasMaxLength(400);
            });

            modelBuilder.Entity<SanctionLists>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommentsField).HasMaxLength(50);

                entity.Property(e => e.CountryField).HasMaxLength(50);

                entity.Property(e => e.ElementIds)
                    .HasColumnName("ElementIDs")
                    .HasMaxLength(400);

                entity.Property(e => e.LoadDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NameSpace).HasMaxLength(200);

                entity.Property(e => e.TermField).HasMaxLength(200);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SanctionMatches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.SanctionComments).HasColumnType("ntext");

                entity.Property(e => e.SanctionListId).HasColumnName("SanctionListID");

                entity.Property(e => e.SanctionTerm).HasMaxLength(400);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.CompleteDate).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TableTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TaskCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RecurrenceId).HasColumnName("RecurrenceID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Transactions>(entity =>
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

            modelBuilder.Entity<TransactionSources>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TransactionTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UserCompanies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("IX_Users_Username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserProfileId)
                    .HasColumnName("UserProfileID")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<XmlwithOpenXml>(entity =>
            {
                entity.ToTable("XMLwithOpenXML");

                entity.Property(e => e.LoadedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Xmldata)
                    .HasColumnName("XMLData")
                    .HasColumnType("xml");
            });
        }
    }
}
