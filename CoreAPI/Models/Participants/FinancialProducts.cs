using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class FinancialProducts
    {
        public int Id { get; set; }
        public int? ProductTypeId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
    }
}
