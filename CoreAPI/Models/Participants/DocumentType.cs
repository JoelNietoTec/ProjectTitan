using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public bool? RequiredIndividual { get; set; }
        public bool? RequiredEntity { get; set; }
    }
}
