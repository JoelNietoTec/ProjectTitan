using System;
using System.Collections.Generic;

namespace WebAPI.Models.Financial
{
    public partial class ParticipantProfile
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public decimal? Total { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal? MonthlyIncomeLimit { get; set; }
        public decimal? MonthlyExpenseLimit { get; set; }
        public int TransactionsLimit { get; set; }
    }
}
