using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParamTables
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModificateDate { get; set; }
        public int TableTypeId { get; set; }

    }
}
