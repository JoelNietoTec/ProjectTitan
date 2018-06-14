using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Projects
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public string EndDate { get; set; }
    }
}
