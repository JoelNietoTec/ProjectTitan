using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Params
{
    public partial class Param
    {
        private Param(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;
        public int Id { get; set; }
        public int ParamCategoryId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public int ParamTableId { get; set; }
        public decimal? Weighting { get; set; }

        private ParamTable _table;

        public ParamTable Table
        {
            get => LazyLoader?.Load(this, ref _table);
            set => _table = value;
        }
    }
}
