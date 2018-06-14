using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Comparisons
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string File { get; set; }
    }
}
