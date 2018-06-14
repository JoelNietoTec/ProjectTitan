﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Param
    {
        public int Id { get; set; }
        public int ParamCategoryId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public int ParamTableId { get; set; }
        public decimal? Weighting { get; set; }
    }
}
