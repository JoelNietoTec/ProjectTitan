namespace TitanWebAPI.Models.Countries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        public int ID { get; set; }

        public int ContinentID { get; set; }

        public int RegionID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string OfficialName { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        [Column("English Name")]
        [StringLength(100)]
        public string English_Name { get; set; }

        [StringLength(200)]
        public string EnglishOfficialName { get; set; }

        [StringLength(50)]
        public string EnglishShortName { get; set; }

        [StringLength(50)]
        public string Demonyn { get; set; }

        [StringLength(50)]
        public string EnglishDemonyn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Score { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual Region Region { get; set; }
    }
}
