using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Schedules
    {
        public int Id { get; set; }
        public int? Year { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public bool? Status { get; set; }
    }
}
