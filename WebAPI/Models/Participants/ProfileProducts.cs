using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ProfileProducts
    {
        public int Id { get; set; }
        public int? ParticipantProfileId { get; set; }
        public int? FinancialProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? MonthlyPayment { get; set; }
        public decimal? Balance { get; set; }
    }
}
