using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Banks
    {
        public int Id { get; set; }
        public int BankTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
