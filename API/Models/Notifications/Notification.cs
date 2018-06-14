namespace TitanWebAPI.Models.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int ID { get; set; }

        public int NotificationTypeID { get; set; }

        public virtual NotificationType NotificationType { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public DateTime? Date { get; set; }

        public int? ElementID { get; set; }
    }
}
