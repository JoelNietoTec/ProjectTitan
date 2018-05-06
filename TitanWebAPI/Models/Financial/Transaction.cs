namespace TitanWebAPI.Models.Financial
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Transaction
    {
        public int ID { get; set; }

        public int TransactionTypeID { get; set; }

        public int ParticipantID { get; set; }

        public virtual Participant Participant { get; set; }

        public int ProfileProductID { get; set; }

        public virtual ProfileProduct ProfileProduct { get; set; }

        public int TransactionSourceID { get; set; }

        public virtual FinancialProfile ParticipantProfile { get; set; }

        public int ParticipantProfileID { get; set; }

        public virtual TransactionType TransactionType { get; set; }

        public virtual TransactionSource TransactionSource { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AccountID { get; set; }

        public virtual ProfileAccount Account { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public decimal? Amount { get; set; }
    }
}
