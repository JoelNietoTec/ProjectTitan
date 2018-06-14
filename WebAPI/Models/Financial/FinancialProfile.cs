namespace WebAPI.Models.Financial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FinancialProfile
    {

        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public decimal? Total { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public decimal? MonthlyIncomeLimit { get; set; }

        public decimal? MonthlyExpenseLimit { get; set; }

        public int TransactionsLimit { get; set; }

        public decimal? IncomeYTD { get; set; }

        public decimal? IncomeMTD { get; set; }

        public decimal? ExpenseYTD { get; set; }

        public decimal? ExpenseMTD { get; set; }
    }
}