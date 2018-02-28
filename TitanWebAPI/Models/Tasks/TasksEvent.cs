using System;

namespace TitanWebAPI.Models.Tasks
{
    public class TasksEvent
    {
        public int id { get; set; }

        public string title { get; set; }

        public DateTime? start { get; set; }

        public DateTime? end { get; set; }

        public string color { get; set; }
    }
}