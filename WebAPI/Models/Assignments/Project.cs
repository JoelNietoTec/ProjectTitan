using System;

namespace WebAPI.Models.Assignments
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Boolean? Active { get; set; }
    }
}
