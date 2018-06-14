using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public int NotificationTypeId { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int? ElementId { get; set; }
    }
}
