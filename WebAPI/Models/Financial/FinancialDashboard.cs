using System;

namespace WebAPI.Models.Financial
{
    public partial class FinancialDashboard
    {
        public Int64 ID { get; set; }
        public int ParticipantID { get; set; }
        public int Month { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }
        public string Source { get; set; }
        public string Bank { get; set; }
        public string ProfileProduct { get; set; }
        public string FinancialProduct { get; set; }
        public string ProductType { get; set; }
        public decimal? Amount { get; set; }
    }
}
