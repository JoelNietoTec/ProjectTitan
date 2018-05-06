using System;

namespace TitanWebAPI.Models.Financial
{
    public class ProfileProduct
    {
        public int ID { get; set; }

        public int ParticipantProfileID { get; set; }

        public FinancialProfile ParticipantProfile { get; set; }

        public int FinancialProductID { get; set; }

        public virtual FinancialProduct FinancialProduct { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public Decimal? MonthlyPayment { get; set; }

        public Decimal? Balance { get; set; }
    }
}