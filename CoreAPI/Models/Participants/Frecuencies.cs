using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class Frecuencies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public int? Days { get; set; }
    }
}
