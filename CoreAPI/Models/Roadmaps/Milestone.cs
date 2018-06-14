using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Roadmaps
{
    public partial class Milestone
    {
        private Milestone(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;

        public int Id { get; set; }
        public int PhaseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Completion { get; set; }
        public int? RecurrenceId { get; set; }
        private Recurrence _recurrence;

        public Recurrence Recurrence
        {
            get => LazyLoader?.Load(this, ref _recurrence);
            set => _recurrence = value;
        }

    }
}
