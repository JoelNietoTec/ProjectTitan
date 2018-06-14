using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Roadmaps
{
    public partial class Phase
    {
        private Phase(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;
        public int Id { get; set; }
        public int RoadmapId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        private ICollection<Milestone> _milestones;

        public ICollection<Milestone> Milestones
        {
            get => LazyLoader?.Load(this, ref _milestones);
            set => _milestones = value;
        }

    }
}
