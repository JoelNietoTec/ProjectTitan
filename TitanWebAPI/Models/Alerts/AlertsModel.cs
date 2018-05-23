namespace TitanWebAPI.Models.Alerts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AlertsModel : DbContext
    {
        public AlertsModel()
            : base("name=AzureServer")
        {
        }

        public virtual DbSet<AlertReason> AlertReasons { get; set; }
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<AlertSource> AlertSources { get; set; }
        public virtual DbSet<AlertPriority> AlertPriorities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
