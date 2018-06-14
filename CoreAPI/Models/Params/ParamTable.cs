using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Params
{
    public partial class ParamTable
    {

        private ParamTable(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;

        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModificateDate { get; set; }
        public int TableTypeId { get; set; }

        private TableType _type;

        public TableType Type
        {
            get => LazyLoader?.Load(this, ref _type);
            set => _type = value;
        }

    }
}
