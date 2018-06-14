using System;
using System.Collections.Generic;

namespace WebAPI.Models.Financial
{
    public partial class Bank
    {
        public int Id { get; set; }
        public int BankTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
