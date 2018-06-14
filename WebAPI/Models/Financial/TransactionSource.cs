using System;
using System.Collections.Generic;

namespace WebAPI.Models.Financial
{
    public partial class TransactionSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
    }
}
