namespace TitanWebAPI.Models.Alerts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlertReason
    {
        public int ID { get; set; }

        public int? AlertSourceID { get; set; }

        public virtual AlertSource AlertSource { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }

        public int AlertPriorityID { get; set; }

        public virtual AlertPriority AlertPriority { get; set; }

        public string Code { get; set; }
    }
}
