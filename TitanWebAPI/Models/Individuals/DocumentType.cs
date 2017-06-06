namespace TitanWebAPI.Models.Individuals
{
    using System.ComponentModel.DataAnnotations;

    public partial class DocumentType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }
    }
}
