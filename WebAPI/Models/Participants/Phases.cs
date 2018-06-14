using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Phases
    {
        public int Id { get; set; }
        public int RoadmapId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
