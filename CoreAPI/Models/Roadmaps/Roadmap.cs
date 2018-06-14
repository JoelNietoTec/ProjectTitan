using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Roadmaps
{
    public partial class Roadmap
    {
        private Roadmap(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Year { get; set; }
        public bool? Active { get; set; }
        public bool? Completed { get; set; }

        private ICollection<Phase> _phases;

        public ICollection<Phase> Phases
        {
            get => LazyLoader?.Load(this, ref _phases);
            set => _phases = value;
        }
    }
}
