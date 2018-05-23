namespace TitanWebAPI.Models.Financial
{
    using System;
    using System.Collections.Generic;

    public partial class ParticipantProfile
    {

        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public decimal? Total { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public decimal? MonthlyIncomeLimit { get; set; }

        public decimal? MonthlyExpenseLimit { get; set; }

        public int TransactionsLimit { get; set; }
    }
}
