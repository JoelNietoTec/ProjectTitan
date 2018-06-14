using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class NotificationTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
