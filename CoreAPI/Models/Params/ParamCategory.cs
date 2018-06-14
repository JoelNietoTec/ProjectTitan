using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Params
{
    public partial class ParamCategory
    {
        
        private ParamCategory(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;

        private ICollection<Param> _params;

        public int Id { get; set; }
        public int ParamMatrixId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public decimal? Weighting { get; set; }

        public ICollection<Param> Params
        {
            get => LazyLoader?.Load(this, ref _params);
            set => _params = value;
        }
    }
}
