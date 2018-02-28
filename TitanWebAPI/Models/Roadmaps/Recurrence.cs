namespace TitanWebAPI.Models.Roadmaps
{
    using System.ComponentModel.DataAnnotations;

    public partial class Recurrence
    {

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string EnglishName { get; set; }
    }
}
