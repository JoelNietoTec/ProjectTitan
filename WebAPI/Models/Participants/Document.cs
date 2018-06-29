using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        [JsonIgnore]
        public byte[] File { get; set; }

        public string Type { get; set; }
    }
}
