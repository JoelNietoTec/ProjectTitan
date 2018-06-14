namespace TitanWebAPI.Models.Alerts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlertPriority
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }
    }
}