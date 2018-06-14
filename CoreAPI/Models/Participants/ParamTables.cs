using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class ParamTables
    {
        public ParamTables()
        {
            ParamValues = new HashSet<ParamValues>();
            Params = new HashSet<Param>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModificateDate { get; set; }
        public int TableTypeId { get; set; }

        public ICollection<ParamValues> ParamValues { get; set; }
        public ICollection<Param> Params { get; set; }
    }
}
