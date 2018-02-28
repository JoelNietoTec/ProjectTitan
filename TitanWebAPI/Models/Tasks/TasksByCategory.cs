namespace TitanWebAPI.Models.Tasks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TasksByCategories")]
    public partial class TasksByCategory
    {
        public int? Count { get; set; }

        [Key]
        [Column(Order = 0)]
        public int CategoryID { get; set; }

        public string Category { get; set; }

        [Key]
        [Column(Order = 1)]
        public int StatusID { get; set; }

        public string Status { get; set; }
    }
}