﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models.Settings
{
    public partial class FinancialProduct
    {
        public int Id { get; set; }
        public int? ProductTypeId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public virtual ProductType Type { get; set; }
    }
}
