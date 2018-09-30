using System;
using System.Collections.Generic;

namespace WebAPI.Models.Discards
{
    public partial class SanctionedItem
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public virtual SanctionList List { get; set; }
        public string Term1 { get; set; }
        public string Term2 { get; set; }
        public string FullTerm
        {
            get
            {
                if (Term1[Term1.Length - 1] == '"')
                    return Term1;
                else
                    return Term1 + " " + Term2;
            }
        }
        public string Term3 { get; set; }
        public string Term4 { get; set; }
        public string Comments { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public DateTime? Date { get; set; }
    }
}
