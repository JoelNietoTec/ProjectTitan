using System;

namespace TitanWebAPI.Models.Tasks
{
    public class TasksEvent
    {
        public Int64 id { get; set; }

        public int taskid { get; set; }

        public int categoryid { get; set; }

        public string title { get; set; }

        public DateTime? start { get; set; }

        public DateTime? end { get; set; }

        public string color { get; set; }
    }
}