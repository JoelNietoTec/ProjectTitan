namespace TitanWebAPI.Models.Financial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        public int ID { get; set; }

        public int TransactionTypeID { get; set; }

        public virtual TransactionType TransactionType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AccountID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public decimal? Amount { get; set; }
    }
}
