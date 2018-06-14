using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class AlertReasons
    {
        public int Id { get; set; }
        public int? AlertSourceId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public int? AlertPriorityId { get; set; }
        public string Code { get; set; }
    }
}
