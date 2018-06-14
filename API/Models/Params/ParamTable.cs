namespace TitanWebAPI.Models.Params
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class ParamTable
    {

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModificateDate { get; set; }

        public int TableTypeID { get; set; }

        public virtual TableType TableType { get; set; }

    }
}
