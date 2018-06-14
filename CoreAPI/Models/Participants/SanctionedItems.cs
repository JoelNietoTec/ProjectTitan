using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class SanctionedItems
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public string Term1 { get; set; }
        public string Term2 { get; set; }
        public string Term3 { get; set; }
        public string Term4 { get; set; }
        public string Comments { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public DateTime? Date { get; set; }
    }
}
