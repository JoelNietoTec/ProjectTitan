namespace TitanWebAPI.Models.Participants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sanction
    {
        public int ID { get; set; }

        public int? ListID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(1000)]
        public string Term1 { get; set; }

        [StringLength(1000)]
        public string Term2 { get; set; }

        [StringLength(1000)]
        public string Term3 { get; set; }

        [StringLength(1000)]
        public string Term4 { get; set; }

        [StringLength(2000)]
        public string Term5 { get; set; }
    }
}
