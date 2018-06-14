using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Settings
{
    public partial class Bank
    {
        private Bank(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;
        public int Id { get; set; }
        public int BankTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        private BankType _type;

        public BankType Type
        {
            get => LazyLoader?.Load(this, ref _type);
            set => _type = value;
        }
    }
}
