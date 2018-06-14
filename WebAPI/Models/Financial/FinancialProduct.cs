using System;
using System.Collections.Generic;

namespace WebAPI.Models.Financial
{
    public partial class FinancialProduct
    {
        public int Id { get; set; }
        public int? ProductTypeId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
    }
}
