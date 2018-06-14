using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ProfileAccounts
    {
        public int Id { get; set; }
        public int? ParticipantProfileId { get; set; }
        public int? BankId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? AccountTypeId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? MonthlyIncomeLimit { get; set; }
        public decimal? MonthlyExpenseLimit { get; set; }
    }
}
