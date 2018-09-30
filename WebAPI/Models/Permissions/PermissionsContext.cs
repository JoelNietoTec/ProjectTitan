using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Permissions
{
    public partial class PermissionsContext : DbContext
    {
        public PermissionsContext()
        {
        }
        public PermissionsContext(DbContextOptions<PermissionsContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<PlanPermission> PlanPermissions { get; set; }

    }
}