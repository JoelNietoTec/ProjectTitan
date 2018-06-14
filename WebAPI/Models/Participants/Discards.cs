using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Discards
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public DateTime? Date { get; set; }
    }
}
