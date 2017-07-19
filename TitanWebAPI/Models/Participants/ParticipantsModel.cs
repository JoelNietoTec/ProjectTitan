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
        public virtual DbSet<Participant> Individuals { get; set; }
        public virtual DbSet<ParticipantsDocument> ParticipantsDocuments { get; set; }
        public virtual DbSet<ParticipantType> ParticipantTypes { get; set; }
        public virtual DbSet<ParticipantContacts> ParticipantContacts { get; set; }
        public virtual DbSet<ParticipantParam> ParticipantParams { get; set; }
        public virtual DbSet<ParamMatrix> ParamMatrices { get; set; }
        public virtual DbSet<ParamCategory> ParamCategories { get; set; }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<ParamValue> ParamValues { get; set; }
        public virtual DbSet<ParamSubValue> ParamSubValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>();

            modelBuilder.Entity<Gender>();

            modelBuilder.Entity<ParticipantType>();

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.ParticipantsDocuments);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.ParticipantParams);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.ParticipantContacts);

            modelBuilder.Entity<ParticipantsDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<ParamMatrix>()
                .HasMany(e => e.ParamCategories);

            modelBuilder.Entity<ParamCategory>()
                .HasMany(e => e.Params);
        }
    }
}
