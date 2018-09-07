using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Segment
    {
        public Int64 Id { get; set; }
        public string ValueName { get; set; }
        public string EnglishValueName { get; set; }
        public int? ValueId { get; set; }
        public int? SubValueId { get; set; }
        public int Count { get; set; }      

        public virtual ICollection<SegmentMember> Members { get; set; }
    }

}