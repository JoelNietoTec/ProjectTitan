using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Financial
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
    }
}
