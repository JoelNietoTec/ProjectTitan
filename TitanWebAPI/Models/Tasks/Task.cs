namespace TitanWebAPI.Models.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int? StatusID { get; set; }

        public int? ParticipantID { get; set; }
    }
}
