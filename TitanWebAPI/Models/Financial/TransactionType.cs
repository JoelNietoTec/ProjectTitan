﻿namespace TitanWebAPI.Models.Financial
{
    using System.ComponentModel.DataAnnotations;

    public partial class TransactionType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
