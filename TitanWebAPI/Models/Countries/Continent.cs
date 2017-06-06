namespace TitanWebAPI.Models.Countries
{
    using System.ComponentModel.DataAnnotations;

    public partial class Continent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishName { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

    }
}
