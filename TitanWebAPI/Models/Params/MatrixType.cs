namespace TitanWebAPI.Models.Params
{
    using System.ComponentModel.DataAnnotations;

    public class MatrixType
    {
        public int ID { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishName { get; set; }
    }
}