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
        public virtual DbSet<ParticipantType> ParticipantTypes { get; set; }
        public virtual DbSet<ParticipantContacts> ParticipantContacts { get; set; }
        public virtual DbSet<ParticipantParam> ParticipantParams { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }
        public virtual DbSet<ParamSubValue> ParamSubValues { get; set; }
        public virtual DbSet<DocumentCountry> DocumentCountries { get; set; }
        public virtual DbSet<ParticipantsByRisk> ParticipantsByRisk { get; set; }
        public virtual DbSet<ParticipantRelationship> ParticipantRelationships { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>();

            modelBuilder.Entity<Gender>();

            modelBuilder.Entity<ParticipantType>();

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.ParticipantDocuments);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.Relationships);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.ParticipantParams);

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
        }

        public System.Data.Entity.DbSet<TitanWebAPI.Models.Participants.Document> Documents { get; set; }
    }
}
