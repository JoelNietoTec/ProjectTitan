using System;

namespace WebAPI.Models.Params
{
    public partial class ParamTable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModificateDate { get; set; }
        public int TableTypeId { get; set; }

        public virtual TableType Type { get; set; }
    }
}
