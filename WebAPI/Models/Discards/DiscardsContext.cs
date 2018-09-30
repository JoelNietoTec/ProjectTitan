using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Discards
{
    public partial class DiscardsContext : DbContext
    {
        public DiscardsContext()
        {
        }
        public DiscardsContext(DbContextOptions<DiscardsContext> options)
            : base(options)
        {
        }
        public virtual DbSet<SanctionList> SanctionLists { get; set; }
        public virtual DbSet<SanctionedItem> SanctionedItems { get; set; }
        public virtual DbSet<ParticipantDiscard> ParticipantDiscards { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<SanctionMatch> SanctionMatches { get; set; }
    }
}