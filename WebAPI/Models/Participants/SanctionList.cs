using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class SanctionList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string NameSpace { get; set; }
        public string ElementIds { get; set; }
        public string TermField { get; set; }
        public string CommentsField { get; set; }
        public string CountryField { get; set; }
        public bool? ActiveSearch { get; set; }
        public DateTime? LoadDate { get; set; }
    }
}
