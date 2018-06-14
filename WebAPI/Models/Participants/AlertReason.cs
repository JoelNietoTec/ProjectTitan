using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class AlertReason
    {
        public int Id { get; set; }
        public int? AlertSourceId { get; set; }
        public virtual AlertSource Source { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public int? AlertPriorityId { get; set; }
        public virtual AlertPriority Priority { get; set; }
        public string Code { get; set; }
    }
}
