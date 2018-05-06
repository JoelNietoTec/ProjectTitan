namespace TitanWebAPI.Models.Sanctions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SanctionList
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        [StringLength(50)]
        public string ElementIDs { get; set; }

        [StringLength(50)]
        public string TermField { get; set; }

        [StringLength(50)]
        public string CommentsField { get; set; }

        [StringLength(50)]
        public string CountryField { get; set; }

        public bool? ActiveSearch { get; set; }
    }
}
