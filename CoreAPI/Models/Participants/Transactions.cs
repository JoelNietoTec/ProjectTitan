using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? ProfileProductId { get; set; }
        public int? ParticipantId { get; set; }
        public int? ParticipantProfileId { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? TransactionSourceId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
    }
}
