namespace TitanWebAPI.Models.Users
{
    using System.Data.Entity;

    public partial class UsersModel : DbContext
    {
        public UsersModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
        }

    }
}