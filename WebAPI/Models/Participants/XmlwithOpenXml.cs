﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class XmlwithOpenXml
    {
        public int Id { get; set; }
        public string Xmldata { get; set; }
        public DateTime? LoadedDateTime { get; set; }
    }
}
