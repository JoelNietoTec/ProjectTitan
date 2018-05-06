namespace TitanWebAPI.Models.Participants
{
    using System.Data.Entity;

    public partial class ParticipantsModel : DbContext
    {
        public ParticipantsModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ParticipantDocument> ParticipantDocuments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<ParticipantType> ParticipantTypes { get; set; }
        public virtual DbSet<ParticipantContact> ParticipantContacts { get; set; }
        public virtual DbSet<ParticipantParam> ParticipantParams { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }
        public virtual DbSet<ParamSubValue> ParamSubValues { get; set; }
        public virtual DbSet<DocumentCountry> DocumentCountries { get; set; }
        public virtual DbSet<ParticipantsByRisk> ParticipantsByRisk { get; set; }
        public virtual DbSet<ParticipantsByCountry> ParticipantsByCountry { get; set; }
        public virtual DbSet<ParticipantRelationship> ParticipantRelationships { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ParticipantNationality> Nationalities { get; set; }
        public virtual DbSet<Discard> Discards { get; set; }
        public virtual DbSet<DiscardMatch> DiscardMatches { get; set; }
        public virtual DbSet<Sanction> Sanctions { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<PendingDocument> PendingDocuments { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Comparison> Comparisons { get; set; }
        public virtual DbSet<AlertType> AlertTypes { get; set; }
        public virtual DbSet<ParticipantAlert> ParticipantAlerts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>();

            /*modelBuilder.Entity<ParticipantNationality>()
                .HasKey(c => new { c.ParticipantID, c.CountryID });
                */
            modelBuilder.Entity<Gender>();

            modelBuilder.Entity<ParticipantType>();

            /*
            modelBuilder.Entity<Participant>()
                .HasMany<ParticipantCountry>(c => c.Nationalities)
                .WithMany(n => n.Participants)
                .Map(cn =>
                {
                    cn.MapLeftKey("ParticipantID");
                    cn.MapRightKey("CountryID");
                    cn.ToTable("ParticipantNationalities");
                });
                */
            modelBuilder.Entity<Participant>()
                .HasMany(e => e.ParticipantContacts);

            modelBuilder.Entity<ParticipantDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentCountry>();

            modelBuilder.Entity<ParamMatrix>()
                .HasMany(e => e.ParamCategories);

            modelBuilder.Entity<ParamCategory>()
                .HasMany(e => e.Params);

            modelBuilder.Entity<ParticipantsByRisk>();

            modelBuilder.Entity<ParticipantsByCountry>();

        }

    }
}