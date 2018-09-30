using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Pendings
{
    public partial class PendingsContext : DbContext
    {
        public PendingsContext()
        {
        }

        public PendingsContext(DbContextOptions<PendingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Pending> Pendings { get; set; }

    }
}