namespace TitanWebAPI.Models.Financial
{
    using System.ComponentModel.DataAnnotations;

    public partial class ProfileAccount
    {
        public int ID { get; set; }

        public int ParticipantProfileID { get; set; }

        public FinancialProfile ParticipantProfile { get; set; }

        public int BankID { get; set; }

        public virtual Bank Bank { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public int? AccountTypeID { get; set; }

        public virtual AccountType AccountType { get; set; }

        public decimal? Amount {get; set;}

        public decimal? MonthlyIncomeLimit { get; set; }

        public decimal? MonthlyExpenseLimit { get; set; }
    }
}
