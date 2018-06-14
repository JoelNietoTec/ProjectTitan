using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Params
{
    public partial class ParamValue
    {
        private ParamValue(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader; 

        public int Id { get; set; }
        public int ParamTableId { get; set; }
        public string DisplayValue { get; set; }
        public string EnglishDisplayValue { get; set; }
        public decimal? Score { get; set; }

        private ICollection<ParamSubValue> _subValues;
        public ICollection<ParamSubValue> SubValues
        {
            get => LazyLoader?.Load(this, ref _subValues);
            set => _subValues = value;
        }
    }
}
