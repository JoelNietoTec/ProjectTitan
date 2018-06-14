using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] File { get; set; }
    }
}
