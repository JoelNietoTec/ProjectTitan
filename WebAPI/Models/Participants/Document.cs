using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Document
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
    }
}
