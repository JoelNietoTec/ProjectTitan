using System;

namespace WebAPI.Models.Pendings
{
    public partial class Pending
    {
        public int Id { get; set; }
        public int? PendingTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public int? ParticipantId { get; set; }
        public int? StageId { get; set; }
        public virtual Stage Stage { get; set; }
    }
}