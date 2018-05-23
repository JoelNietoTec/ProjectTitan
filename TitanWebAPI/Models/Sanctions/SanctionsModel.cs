namespace TitanWebAPI.Models.Sanctions
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SanctionsModel : DbContext
    {
        public SanctionsModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<SanctionList> SanctionLists { get; set; }
        public virtual DbSet<Sanction> Sanctions { get; set; }
        public virtual DbSet<SanctionedItem> SanctionedItems { get; set; }
        public virtual DbSet<SanctionMatch> SanctionMatches { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
