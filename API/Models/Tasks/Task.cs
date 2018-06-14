namespace TitanWebAPI.Models.Tasks
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Task
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public virtual TaskCategory Category { get; set; }

        public int ProjectID { get; set; }

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

        public virtual Participant Participant { get; set; }
    }
}
