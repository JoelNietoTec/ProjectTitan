using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Abbreviation { get; set; }
        public string Code { get; set; }
        public bool BlackList { get; set; }
    }
}
